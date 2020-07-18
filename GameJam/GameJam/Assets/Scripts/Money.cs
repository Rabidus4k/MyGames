using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        MoneyPlayer.money++;
        GameObject.FindGameObjectWithTag ("Player").GetComponent<MoneyPlayer>().TextMoney.text = "Bits: " + MoneyPlayer.money.ToString();
        Destroy(gameObject);
    }
}
