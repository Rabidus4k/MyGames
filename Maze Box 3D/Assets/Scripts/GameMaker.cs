using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class GameMaker : MonoBehaviour
{
    #region VARIABLES

    public static GameMaker inst;

    //кнопка ячейки
    public GameObject _CellButton;

    //Поле ввода ширины карты
    public InputField _WidthField;
    //Поле ввода высоты карты
    public InputField _HeightField;

    //Префаб блока стены
    public GameObject _WallBlockPref;
    //Префаб пола
    public GameObject _CellFloorPref;
    public GameObject _PathFloorPref;
    //Пребаю игрока
    public GameObject _PlayerPref;
    //Поле, где отображаются ячейки
    public GameObject _DrawField;

    public GameObject _Camera;
    public GameObject _PreviewButton;
    public GameObject _ExitPreviewButton;


    //Определяет, является ли данный пользователь разработчиком (только при работе на компьютере)
    public bool isDeveloper = false;

    private int _Width;
    private int _Height;

    //Массив, хранящий все ячейки поля
    private List<List<GameObject>> _CellsArray;

    #endregion

    #region METHODS

    /// <summary>
    /// При изменении статуса пользователя, меняет его статус
    /// </summary>
    public void OnDeveloper()
    {
        isDeveloper = !isDeveloper;
    }

    /// <summary>
    /// При нажатии на кнопку Apply обновляется поле и русуются новые ячейки с новым размером
    /// </summary>
    public void OnApplyClicked()
    {
        inst = this;
        DeleteField();
        SetSize();
        GenerateField();
        Preset();
        SetColors();
    }

    /// <summary>
    /// Удаление текущего поля
    /// </summary>
    private void DeleteField()
    {
        if (_CellsArray != null)
        {
            for (int i = 0; i < _Height; i++)
            {
                for (int j = 0; j < _Width; j++)
                {
                    if (_CellsArray[i][j] != null)
                        Destroy(_CellsArray[i][j]);
                }
            }
            _CellsArray.Clear();
        }
    }

    /// <summary>
    /// Удаление всех объектов карты с поля
    /// </summary>
    private void CleareMap()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach(GameObject obj in walls)
        {
            Destroy(obj);
        }

        GameObject[] cells = GameObject.FindGameObjectsWithTag("CellTrigger");
        foreach (GameObject obj in cells)
        {
            Destroy(obj);
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
    }

    public void PreviewMapExitClicked()
    {
        CleareMap();
        _PreviewButton.SetActive(true);
        _ExitPreviewButton.SetActive(false);
        _DrawField.SetActive(true);
    }

    /// <summary>
    /// Генерация карты для последующего её теста
    /// </summary>
    public void PreviewMapClicked()
    {
        _PreviewButton.SetActive(false);
        _ExitPreviewButton.SetActive(true);

        CleareMap();

        _DrawField.SetActive(false);
        _Camera.transform.position = new Vector3((_Height / 2.0f) - 1, _Camera.transform.position.y, _Camera.transform.position.z);
        for (int i = 0; i < _Height; i++)
        {
            for (int j = 0; j < _Width; j++)
            {
                string tempCell = _CellsArray[i][j].GetComponentInChildren<Text>().text.ToString();
                if (tempCell == "0")
                {
                    Instantiate(_CellFloorPref, new Vector3(i, 0, j), Quaternion.identity);
                }
                if (tempCell == "1")
                {
                    Instantiate(_PathFloorPref, new Vector3(i, 0, j), Quaternion.identity);
                }
                if (tempCell == "2")
                {
                    Instantiate(_WallBlockPref, new Vector3(i, 0.5f, j), Quaternion.identity);
                }
                if (tempCell == "3")
                {
                    GameObject newPlayer = Instantiate(_PlayerPref, new Vector3(i, 0.5f, j), Quaternion.identity);
                    newPlayer.GetComponent<PlayerMovement>()._InEditor = true;
                    Instantiate(_PathFloorPref, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
    }

    /// <summary>
    /// Генерация поля с ячейками
    /// </summary>
    private void GenerateField()
    {
        _CellsArray = new List<List<GameObject>>();

        for (int i = 0; i < _Height; i++)
        {
            _CellsArray.Add(new List<GameObject>());

            for (int j = 0; j < _Width; j++)
            {
                GameObject newCell = Instantiate(_CellButton, _DrawField.transform);

                newCell.transform.localPosition = new Vector2(j * (100), i * (-100));

                newCell.GetComponent<BtnInfo>().x = j;
                newCell.GetComponent<BtnInfo>().y = i;

                _CellsArray[i].Add(newCell);
            }
        }
    }

    /// <summary>
    /// Установка цветов ячеек в соответствии с их типом
    /// </summary>
    private void SetColors()
    {
        for (int i = 0; i < _Height; i++)
        {
            for (int j = 0; j < _Width; j++)
            {
                switch (_CellsArray[i][j].GetComponentInChildren<Text>().text)
                {
                    case ("0"):
                        {
                            _CellsArray[i][j].GetComponent<Image>().color = Color.gray;
                        }
                        break;
                    case ("1"):
                        {
                            _CellsArray[i][j].GetComponent<Image>().color = Color.magenta;
                        }
                        break;
                    case ("2"):
                        {
                            _CellsArray[i][j].GetComponent<Image>().color = Color.white;
                        }
                        break;
                    case ("3"):
                        {
                            _CellsArray[i][j].GetComponent<Image>().color = Color.green;
                        }
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Сохранение карты в XML файл
    /// </summary>
    public void SaveMap()
    {
        string path;
        XmlDocument doc = new XmlDocument();

        //Если пользователь является разработчиком, что сохраняться новая карта будет в основной список карт
        if (isDeveloper)
        {
            path = (Application.dataPath + "/Resources/map.xml");
        }
        //Если пользователь не является разработчиком, то карта сохраняется с отдельный файл
        else
        {
            string dirPath = Application.persistentDataPath;
            string fileName = "/newMaps.xml";
            path = dirPath + fileName;

            if (!File.Exists(path))
            {
                if (Directory.Exists(dirPath) == false)
                {
                    Directory.CreateDirectory(path); 
                }
                File.Create(path).Dispose();

                XmlDocument XmlDoc = new XmlDocument();
                XmlElement db = XmlDoc.CreateElement("database");
                db.SetAttribute("name", "database");
                db.SetAttribute("tag", "0");

                XmlDoc.AppendChild(db);

                XmlDoc.Save(path);
            }
        }

        doc.Load(path);

        var dataBase = doc.GetElementsByTagName("database")[0];
        
        int countOfMaps = int.Parse(dataBase.Attributes[1].Value);
        dataBase.Attributes[1].Value = (++countOfMaps).ToString();

        XmlElement newMap = doc.CreateElement("Map");
        newMap.SetAttribute("id", countOfMaps.ToString());

        XmlElement newWidth = doc.CreateElement("Width");
        newWidth.InnerText = _Width.ToString();
        newMap.AppendChild(newWidth);

        XmlElement newHeight = doc.CreateElement("Height");
        newHeight.InnerText = _Height.ToString();
        newMap.AppendChild(newHeight);

        XmlElement newCells = doc.CreateElement("Cells");
       
        string newLine = string.Empty;

        int countOfSteps = 0;

        for (int i = 0; i < _Height; i++)
        {         
            for (int j = 0; j < _Width; j++)
            {
                string tempCell = _CellsArray[i][j].GetComponentInChildren<Text>().text.ToString();
                newLine += tempCell;
                if ("0".Equals(tempCell) || "3".Equals(tempCell) || "1".Equals(tempCell))
                {
                    countOfSteps++;
                }
            }
        }

        XmlElement newCount = doc.CreateElement("Count");

        newCount.InnerText = countOfSteps.ToString();
        newMap.AppendChild(newCount);


        newCells.InnerText = newLine;
        newMap.AppendChild(newCells);

        doc.DocumentElement.AppendChild(newMap);
        doc.Save(path);
    }

    /// <summary>
    /// Установка размеров поля с ячейками
    /// </summary>
    private void SetSize()
    {
        try
        {
            _Width = int.Parse(_WidthField.text);
            _Height = int.Parse(_HeightField.text);

            if (_Width < 3)
            {
                _Width = 3;
                _WidthField.text = "3";
            }
            if (_Height < 3)
            {
                _Height = 3;
                _HeightField.text = "3";
            }
            if (_Width > 20)
            {
                _Width = 20;
                _WidthField.text = "20";
            }
            if (_Height > 20)
            {
                _Height = 20;
                _HeightField.text = "20";
            }

            _DrawField.transform.localScale = new Vector3(6.0f/ _Width, 6.0f/ _Height, 1);
        }
        catch
        {
            Debug.Log("Ошибка");
        }
    }

    /// <summary>
    /// Удаление всех построенных путей с поля
    /// </summary>
    private void Preset()
    {
        for (int i = 0; i < _Height; i++)
        {
            for (int j = 0; j < _Width; j++)
            {
                if (_CellsArray[i][j].GetComponentInChildren<Text>().text == "1")
                    _CellsArray[i][j].GetComponentInChildren<Text>().text = "0";
            }
        }
    }

    /// <summary>
    /// Установка в ячейку [x,y] ячейку нового типа
    /// </summary>
    /// <param name="x">координата ячейки по длине</param>
    /// <param name="y">координата ячейки по высоте(начиная сверху)</param>
    /// <param name="brushType">новый тип ячейки</param>
    public static void UpdateClicked(int x, int y ,int brushType)
    {
        inst.Preset();
        inst.SetblockCells(x,y, brushType);
        inst.SetColors();
    }

    /// <summary>
    /// Изменение типа ячейки, в зависимости от типа кисти
    /// </summary>
    /// <param name="x">координата ячейки по длине</param>
    /// <param name="y">координата ячейки по высоте(начиная сверху)</param>
    /// <param name="brushType">новый тип ячейки</param>
    private void SetblockCells(int x, int y, int brushType)
    {
        switch (brushType)
        {
            case 1:
                {
                    _CellsArray[y][x].GetComponentInChildren<Text>().text = "2";
                }
                break;
            case 2:
                {
                    _CellsArray[y][x].GetComponentInChildren<Text>().text = "3";
                }
                break;
            case 3:
                {
                    _CellsArray[y][x].GetComponentInChildren<Text>().text = "0";
                }
                break;
        }

        RebuildMap();
    }

    /// <summary>
    /// Перестройка путей в матрице ячеек
    /// </summary>
    private void RebuildMap()
    {
        for (int z = 0; z < 10; z++)
        {
            for (int i = 0; i < _Height; i++)
            {
                for (int j = 0; j < _Width; j++)
                {
                    if (_CellsArray[i][j].GetComponentInChildren<Text>().text == "2")
                    {
                        //DOWN
                        if (i + 1 < _Height && _CellsArray[i + 1][j].GetComponentInChildren<Text>().text == "1") //TODO заменит 0 на 1
                        {
                            int k = j;

                            while (k + 1 < _Width)
                            {
                                if (_CellsArray[i + 1][k + 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    if (_CellsArray[i + 1][k + 1].GetComponentInChildren<Text>().text != "3")
                                        _CellsArray[i + 1][k + 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k++;
                            }

                            k = j;

                            while (k - 1 >= 0)
                            {
                                if (_CellsArray[i + 1][k - 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    if (_CellsArray[i + 1][k - 1].GetComponentInChildren<Text>().text != "3")
                                        _CellsArray[i + 1][k - 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k--;
                            }
                        }
                        //UP
                        if (i - 1 >= 0 && _CellsArray[i - 1][j].GetComponentInChildren<Text>().text == "1") //TODO заменит 0 на 1
                        {
                            int k = j;

                            while (k + 1 < _Width)
                            {
                                if (_CellsArray[i - 1][k + 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    if (_CellsArray[i - 1][k + 1].GetComponentInChildren<Text>().text != "3")
                                        _CellsArray[i - 1][k + 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k++;
                            }

                            k = j;

                            while (k - 1 >= 0)
                            {
                                if (_CellsArray[i - 1][k - 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    if (_CellsArray[i - 1][k - 1].GetComponentInChildren<Text>().text != "3")
                                        _CellsArray[i - 1][k - 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k--;
                            }
                        }
                        //LEFT
                        if (j - 1 >= 0 && _CellsArray[i][j - 1].GetComponentInChildren<Text>().text == "1") //TODO заменит 0 на 1
                        {
                            int k = i;

                            while (k + 1 < _Height)
                            {
                                if (_CellsArray[k + 1][j - 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    if (_CellsArray[k + 1][j - 1].GetComponentInChildren<Text>().text != "3")
                                        _CellsArray[k + 1][j - 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k++;
                            }

                            k = i;

                            while (k - 1 >= 0)
                            {
                                if (_CellsArray[k - 1][j - 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    if (_CellsArray[k - 1][j - 1].GetComponentInChildren<Text>().text != "3")
                                        _CellsArray[k - 1][j - 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k--;
                            }
                        }
                        //RIGHT
                        if (j + 1 < _Width && _CellsArray[i][j + 1].GetComponentInChildren<Text>().text == "1") //TODO заменит 0 на 1
                        {
                            int k = i;

                            while (k + 1 < _Height)
                            {
                                if (_CellsArray[k + 1][j + 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    if (_CellsArray[k + 1][j + 1].GetComponentInChildren<Text>().text != "3")
                                        _CellsArray[k + 1][j + 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k++;
                            }

                            k = i;

                            while (k - 1 >= 0)
                            {
                                if (_CellsArray[k - 1][j + 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    if (_CellsArray[k - 1][j + 1].GetComponentInChildren<Text>().text != "3")
                                        _CellsArray[k - 1][j + 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k--;
                            }
                        }
                    }
                    if (_CellsArray[i][j].GetComponentInChildren<Text>().text == "3")
                    {
                        //DOWN
                        if (i + 1 < _Height && _CellsArray[i + 1][j].GetComponentInChildren<Text>().text != "2") //TODO заменит 0 на 1
                        {
                            int k = i;

                            while (k + 1 < _Height)
                            {
                                if (_CellsArray[k + 1][j].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    _CellsArray[k + 1][j].GetComponentInChildren<Text>().text = "1";
                                }
                                k++;
                            } 
                        }
                        //UP
                        if (i - 1 >= 0 && _CellsArray[i - 1][j].GetComponentInChildren<Text>().text != "2") //TODO заменит 0 на 1
                        {
                            int k = i;

                            while (k - 1 >= 0)
                            {
                                if (_CellsArray[k - 1][j].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    _CellsArray[k - 1][j].GetComponentInChildren<Text>().text = "1";
                                }
                                k--;
                            }
                        }
                        //RIGHT
                        if (j + 1 < _Width && _CellsArray[i][j + 1].GetComponentInChildren<Text>().text != "2") //TODO заменит 0 на 1
                        {
                            int k = j;

                            while (k + 1 < _Height)
                            {
                                if (_CellsArray[i][k + 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    _CellsArray[i][k + 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k++;
                            }
                        }
                        //LEFT
                        if (j - 1 >= 0 && _CellsArray[i][j - 1].GetComponentInChildren<Text>().text != "2") //TODO заменит 0 на 1
                        {
                            int k = j;

                            while (k - 1 >= 0)
                            {
                                if (_CellsArray[i][k - 1].GetComponentInChildren<Text>().text == "2")
                                {
                                    break;
                                }
                                else
                                {
                                    _CellsArray[i][k - 1].GetComponentInChildren<Text>().text = "1";
                                }
                                k--;
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
}