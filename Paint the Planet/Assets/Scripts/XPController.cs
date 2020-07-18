using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class XPController : MonoBehaviour
{
    private float _Xp;
    private GameObject _XpBar;
    private TextMeshProUGUI _XpScore;

    public void Start()
    {
        _XpBar = GameObject.FindGameObjectWithTag("XpBar");
        _XpScore = GameObject.FindGameObjectWithTag("XpBarText").GetComponent<TextMeshProUGUI>();
    }

    public void GetXP(float xp)
    {
        _Xp += xp;

        if (_Xp > 100)
        {
            _Xp = 100;
        }

        _XpBar.transform.localScale = new Vector3(_Xp * 0.01f, 1, 1);
        _XpScore.SetText(_Xp.ToString());
    }
}
