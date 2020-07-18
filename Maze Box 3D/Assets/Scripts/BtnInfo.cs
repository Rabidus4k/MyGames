using UnityEngine;

public class BtnInfo : MonoBehaviour
{
    #region VARIABLES 

    public int x;
    public int y;

    #endregion

    #region METHODS 

    /// <summary>
    /// 
    /// </summary>
    public void OnHovered()
    {
        if (Input.GetMouseButton(0))
            GameMaker.UpdateClicked(x, y, BrushType.brushType);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnClicked()
    {
        GameMaker.UpdateClicked(x, y, BrushType.brushType);
    }

    #endregion
}

