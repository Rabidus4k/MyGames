using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelGenetaror : MonoBehaviour
{
    #region VARIABLES

    private static LevelGenetaror inst;

    public GameObject Camera;
    //Номер текущей карты(начиная с 0)
    private int currentMap = 0;
    //Текущий уровень игрока TODO: починить
    private int currentMap2 = 0;
    public int currentLevel = 0;
    public TextMeshProUGUI levelText;

    //префаб описания карты, сделанной в режиме редактора
    public GameObject _MyMapInfoPrefab;
    public GameObject workshop;
    public GameObject cellBlock;
    public GameObject cellFloor;
    private GameObject Player;

    private bool onMyMap = false;

    //Список стандартных карт
    private List<MapInfo> Maps = new List<MapInfo>();
    //Список карт, сделанных в режиме редактора
    private List<MapInfo> MyMaps = new List<MapInfo>();

    //Текущая карта
    private MapInfo curMap;
    
    #endregion

    #region METHODS

    private void Start()
    {
        inst = this;
        Player = GameObject.FindGameObjectWithTag("Player");
        LoadMaps();
        LoadLastLevel();
        PlaceMap(Maps[currentMap]);
    }

    //TODO дописать
    private void LoadLastLevel()
    {
        string dirPath = Application.persistentDataPath;
        string fileName = "info.xml";

        string loadPath = Path.Combine(dirPath, fileName);

        if (File.Exists(loadPath))
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(loadPath);
            var lastLevel = XmlDoc.GetElementsByTagName("LastLevel")[0];
            currentLevel = int.Parse(lastLevel.InnerText);
            inst.levelText.SetText($"LEVEL:\n{inst.currentLevel}");

            if (currentLevel > Maps.Count)
            {
                currentMap = currentLevel % Maps.Count;
            }
            else
            {
                currentMap = currentLevel;
            }
        }
        else
        {
            if (Directory.Exists(dirPath) == false)
            {
                Directory.CreateDirectory(loadPath);                
            }

            File.Create(loadPath).Dispose();
            XmlDocument XmlDoc = new XmlDocument();
            XmlElement Info = XmlDoc.CreateElement("Info");
            XmlElement LastLevel = XmlDoc.CreateElement("LastLevel");
            LastLevel.InnerText = "0";
            Info.AppendChild(LastLevel);
            XmlDoc.AppendChild(Info);

            XmlDoc.Save(loadPath);
            currentMap = 0;
        }      
    }

    private void IncreaseLvl()
    {
        currentLevel++;
        levelText.SetText($"LEVEL:\n{inst.currentLevel}");
    }

    private void LoadMaps()
    {
        onMyMap = false;
        TextAsset textAsset = (TextAsset)Resources.Load("map", typeof(TextAsset));
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);

        var dataBase = xmldoc.GetElementsByTagName("Map");

        foreach(XmlElement map in dataBase)
        {
            int w = int.Parse(map.ChildNodes[0].InnerText);
            int h = int.Parse(map.ChildNodes[1].InnerText);
            int countOfsteps = int.Parse(map.ChildNodes[2].InnerText);
            string cells = map.ChildNodes[3].InnerText;

            Maps.Add(new MapInfo(w, h, cells, countOfsteps));
        }     
    }

    public void RefreshMaps()
    {
        GameObject[] oldMaps = GameObject.FindGameObjectsWithTag("MapButton");
        foreach(var obj in oldMaps)
        {
            Destroy(obj);
        }
        int index = 0;
        LoadMyMaps();
        foreach (MapInfo map in MyMaps)
        {

            Vector3 pos = new Vector3(workshop.transform.position.x, workshop.transform.position.y + (100 * index), workshop.transform.position.z);
            GameObject tempButton = Instantiate(_MyMapInfoPrefab, pos, Quaternion.identity);
            tempButton.GetComponentInChildren<Text>().text = index.ToString();
            tempButton.transform.parent = workshop.transform;
            index++;
        }
    }

    private void LoadMyMaps()
    {
        MyMaps = new List<MapInfo>();

        string dirPath = Application.persistentDataPath;
        string fileName = "/newMaps.xml";
        string path = dirPath + fileName;

        if (!File.Exists(path))
        {
            return;
        }

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(path);

        var dataBase = xmldoc.GetElementsByTagName("Map");

        foreach (XmlElement map in dataBase)
        {
            int w = int.Parse(map.ChildNodes[0].InnerText);
            int h = int.Parse(map.ChildNodes[1].InnerText);
            int countOfsteps = int.Parse(map.ChildNodes[2].InnerText);
            string cells = map.ChildNodes[3].InnerText;

            MyMaps.Add(new MapInfo(w, h, cells, countOfsteps));
        }
    }


    public void DeleteAllMaps()
    {
        string dirPath = Application.persistentDataPath;
        string fileName = "/newMaps.xml";
        string path = dirPath + fileName;

        if (!File.Exists(path))
        {
            return;
        }
        if (MyMaps != null)
            MyMaps.Clear();
        MyMaps = null;

        XmlDocument XmlDoc = new XmlDocument();
        XmlElement db = XmlDoc.CreateElement("database");
        db.SetAttribute("name", "database");
        db.SetAttribute("tag", "0");

        XmlDoc.AppendChild(db);

        XmlDoc.Save(path);
    }


    public void ChangeCliced()
    {
        CleareMap();

        if (!onMyMap)
        {
            if (Maps != null && Maps.Count != 0)
            {
                IncreaseLvl();
                if (currentMap + 1 >= Maps.Count)
                {
                    currentMap = 0;
                }
                else
                {
                    currentMap++;
                    Debug.Log(currentMap);
                }
                PlaceMap(Maps[currentMap]);
            }      
        }
        else
        {
            if (MyMaps != null && MyMaps.Count != 0)
            {
                if (currentMap2 + 1 >= MyMaps.Count)
                {
                    currentMap2 = 0;
                }
                else
                {
                    currentMap2++;
                }
                PlaceMap(MyMaps[currentMap2]);
            }      
            else
            {
                onMyMap = false;
                PlaceMap(Maps[currentMap]);
            }
        }
    }

    public void OnStartButtonClicked()
    {
        CleareMap();
        onMyMap = false;
        PlaceMap(Maps[currentMap]);
    }

#if UNITY_EDITOR

    private void OnApplicationQuit()
    {
        string dirPath = Application.persistentDataPath;
        string fileName = "info.xml";

        string loadPath = Path.Combine(dirPath, fileName);

        if (File.Exists(loadPath))
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(loadPath);

            var lastLevel = XmlDoc.GetElementsByTagName("LastLevel")[0];
            lastLevel.InnerText = currentLevel.ToString();
            XmlDoc.Save(loadPath);
        }
    }
#elif UNITY_ANDROID

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
            return;

        string dirPath = Application.persistentDataPath;
        string fileName = "info.xml";

        string loadPath = Path.Combine(dirPath, fileName);

        if (File.Exists(loadPath))
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(loadPath);

            var lastLevel = XmlDoc.GetElementsByTagName("LastLevel")[0];
            lastLevel.InnerText = currentLevel.ToString();
            XmlDoc.Save(loadPath);
        }
    }
#endif

    public static void ChangeMap()
    { 
        inst.ChangeCliced();
    }


    public static int Steps()
    {
        return inst.curMap._CountOfCells;
    }


    public void CleareMap()
    {
        PlayerMovement._CountOfSteps = 0;

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Wall");
        foreach(var obj in gameObjects)
        {
            Destroy(obj);
        }
        gameObjects = GameObject.FindGameObjectsWithTag("CellTrigger");
        foreach (var obj in gameObjects)
        {
            Destroy(obj);
        }
    }

    public void OnRestartClicked()
    {
        CleareMap();
        if (onMyMap)
            PlaceMap(MyMaps[currentMap]);
        else
            PlaceMap(Maps[currentMap]);
    }

    public static void OnMapChoose(int id)
    {
        inst.currentMap2 = id;
        inst.CleareMap();
        inst.onMyMap = true;
        inst.PlaceMap(inst.MyMaps[id]);
    }

    private void PlaceMap(MapInfo mapInfo)
    {
        curMap = mapInfo;
        Camera.transform.position = new Vector3((mapInfo._Height / 2.0f) - .5f, Camera.transform.position.y, Camera.transform.position.z);
        int count = 0;

        for (int i = 0; i < mapInfo._Height; i++)
        {
            for (int j = 0; j <  mapInfo._Width; j++)
            {
                if (mapInfo._Cells[count] == '0' || mapInfo._Cells[count] == '1')
                {
                    Instantiate(cellFloor, new Vector3(i, 0, j), Quaternion.identity);
                }
                if (mapInfo._Cells[count] == '2')
                {
                    Instantiate(cellBlock, new Vector3(i, 0.5f, j), Quaternion.identity);
                }
                if (mapInfo._Cells[count] == '3')
                {
                    Player.transform.position = new Vector3(i, 0.5f, j);
                    Instantiate(cellFloor, new Vector3(i, 0, j), Quaternion.identity);
                }
                count++;
            }
        }
    }

#endregion
}
