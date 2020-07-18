using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float currentValue { get; set; }

    [SerializeField]
    private GameObject _barToChange;


    private void Start()
    {
        currentValue = 100;
        StartCoroutine(ManaRegeneration(0.1f));

    }

    private IEnumerator ManaRegeneration(float value)
    {
        while (true)
        {
            yield return new WaitForSeconds(value);
            Regeneration();
        }
    }

    private void Regeneration()
    {
        if (currentValue < 100)
        {
            currentValue+=1;
        }
    }

    private void Update()
    {
        _barToChange.transform.localScale = new Vector3(currentValue / 100.0f, 1, 1);
    }

    public void DecreaseValue(float ammount)
    {
        currentValue -= ammount;
        if (currentValue < 0)
        {
            currentValue = 0;
        }
        
    }
}
