using UnityEngine;
using TMPro;
public class BrushType : MonoBehaviour
{
    #region VARIABLES

    //Тип кисти
    public static int brushType = 1;

    public TextMeshProUGUI label;

    public GameObject firstBrush;
    public GameObject secondBrush;
    public GameObject thirdBrush;
    
    #endregion

    #region METHODS

    /// <summary>
    /// Метод меняет текущую кисть на следующуу и запоминает её тип
    /// </summary>
    public void ChangeBrush()
    {
        switch (brushType)
        {
            case 1:
                {
                    firstBrush.SetActive(false);
                    secondBrush.SetActive(true);
                    label.SetText("PLAYER");
                    brushType = 2;
                }
                break;

            case 2:
                {
                    secondBrush.SetActive(false);
                    thirdBrush.SetActive(true);
                    label.SetText("ERASE");
                    brushType = 3;
                }
                break;

            case 3:
                {
                    thirdBrush.SetActive(false);
                    firstBrush.SetActive(true);
                    label.SetText("WALL");
                    brushType = 1;
                }
                break;
        }
    }

    #endregion
}
