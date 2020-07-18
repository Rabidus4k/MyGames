using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class City : MonoBehaviour
{
    public int Index;

    public bool isEating = false;
    public GameObject _bubble;
    public TextMeshProUGUI _bubbleText;
    public static int EatingCount;

    private void Start()
    {
        EatingCount = 0;
    }
    public void Eat()
    {
        if (!isEating)
        {
            EatingCount++;
            isEating = true;
            StartCoroutine("Eatfood");
        }
    }

    public void WantEat()
    {
        if (!isEating)
        {
            StartCoroutine(PrintText("I'm hungry!"));
        }
            
    }

    private IEnumerator Eatfood()
    {
        _bubble.SetActive(false);
        yield return new WaitForSeconds(5f);
        isEating = false;
        EatingCount--;
    }

    private IEnumerator PrintText(string str)
    {
        _bubble.SetActive(true);
        _bubbleText.text = str;

        yield return null; 
    }
}
