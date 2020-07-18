using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private GameObject m_healthBar;

    private void Start()
    {
        m_healthBar = GameObject.FindGameObjectWithTag("HealthBarUI");
    }

    public void SetHealth(float hp)
    {
        m_healthBar.transform.localScale = new Vector3(hp, 1, 1);
    }
}
