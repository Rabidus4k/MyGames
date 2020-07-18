using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPlayer : MonoBehaviour
{
    static public int money;

    [SerializeField]
    public TextMeshProUGUI TextMoney;

    // Start is called before the first frame update
    void Start()
    {
        money = 0;
    }
}
