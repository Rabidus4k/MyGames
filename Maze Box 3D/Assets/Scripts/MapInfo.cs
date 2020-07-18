using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    #region VARIABLES

    public int _Width;
    public int _Height;
    public int _CountOfCells;

    public string _Cells;

    #endregion

    #region METHODS

    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="w">Ширина карты</param>
    /// <param name="h">Высота карты</param>
    /// <param name="cells">Ячейки</param>
    /// <param name="countOfCells">Количество ячеек, которое нужно закрасить</param>
    public MapInfo(int w, int h, string cells, int countOfCells)
    {
        _Width = w;
        _Height = h;
        _Cells = cells;
        _CountOfCells = countOfCells;
    }

    #endregion
}