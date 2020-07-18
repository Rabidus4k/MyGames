using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    #region VARIABLES

    //Длина свайпа
    public Vector2 SwipeDelta { get; set; }

    public bool SwipeLeft { get; set; }
    public bool SwipeRight { get; set; }
    public bool SwipeUp { get; set; }
    public bool SwipeDown { get; set; }

    //Определяет направление свайпа (1 , 2, 3 , 4)
    public int SwipeDirection { get; set; }

    //Определяет, была ли нажата ЛКМ или Тап по экрану
    private bool tap;
    private bool isDraging;
    private Vector2 startTourch;

    #endregion

    #region METHODS

    private void Update()
    {
        tap = SwipeLeft = SwipeRight = SwipeUp = SwipeDown = false;

        #region Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTourch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTourch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        SwipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                SwipeDelta = Input.touches[0].position - startTourch;
            }
            else if (Input.GetMouseButton(0))
            {
                SwipeDelta = (Vector2)Input.mousePosition - startTourch;
            }
        }

        if (SwipeDelta.magnitude > 50)
        {
            float x = SwipeDelta.x;
            float y = SwipeDelta.y;


            if (y >= x && -y <= x)
            {
                SwipeUp = true;
                SwipeDirection = 1;
            }
            else if (y < x && -y > x)
            {
                SwipeDown = true;
                SwipeDirection = 3;
            }
            else if (y > x && -y > x)
            {
                SwipeLeft = true;
                SwipeDirection = 4;
            }
            else if (y < x && -y < x)
            {
                SwipeRight = true;
                SwipeDirection = 2;
            }

            Reset();
        }
    }

    /// <summary>
    /// Восстановление значений по умолчанию
    /// </summary>
    private void Reset()
    {
        startTourch = SwipeDelta = Vector2.zero;
        isDraging = false;
    }

    #endregion
}
