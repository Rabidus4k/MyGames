using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBarController : MonoBehaviour
{
    private GameObject m_strengthBar;
    private static StrengthBarController m_strengthBarController;

    public static float m_strength;

    private void Start()
    {
        m_strength = 1;
        m_strengthBarController = this;
        m_strengthBar = GameObject.FindGameObjectWithTag("StrengthBar");
    }

    private void FixedUpdate()
    {
        AddStrength(0.001f);
    }

    public static void LowStrength(float ammount)
    {
        if (m_strength - ammount >= 0)
        {
            m_strength -= ammount;
        }
        else
        {
            m_strength = 0;
        }

        m_strengthBarController.m_strengthBar.transform.localScale = new Vector3(m_strength, 1, 1);
    }

    private void AddStrength(float ammount)
    {
        if (m_strength + ammount <= 1)
        {
            m_strength += ammount;
        }
        else
        {
            m_strength = 1;
        }
        m_strengthBar.transform.localScale = new Vector3(m_strength, 1, 1);
    }
}
