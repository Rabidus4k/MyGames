using UnityEngine;
using UnityEngine.UI;

public class WorkshopButton : MonoBehaviour
{
    /// <summary>
    /// Спавнит карту, выбранную в меню WorkShop
    /// </summary>
    public void OnClicked()
    {
        LevelGenetaror.OnMapChoose(int.Parse(gameObject.GetComponentInChildren<Text>().text));
    }
}
