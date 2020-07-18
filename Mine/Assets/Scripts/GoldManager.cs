using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    private Text m_goldText;
    private int m_gold = 0;

    private void Start()
    {
        m_goldText = GameObject.FindGameObjectWithTag("GoldTextUI").GetComponent<Text>();
    }
    public void GetGold(int ammount)
    {
        m_gold += ammount;
        m_goldText.text = $"GOLD: {m_gold}";
    }
}

