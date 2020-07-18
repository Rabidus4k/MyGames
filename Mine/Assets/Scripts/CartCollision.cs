using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCollision : MonoBehaviour
{
    private CartMovement m_cartMovement;

    private void Start()
    {
        m_cartMovement = gameObject.GetComponent<CartMovement>();
    }

    #region COLLISON
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Stone"))
        {

        }       
    }   

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Stone"))
        {
            m_cartMovement.SetCartSpeed(Settings.STATRCARTSPEED);
        }
    }
    #endregion
}
