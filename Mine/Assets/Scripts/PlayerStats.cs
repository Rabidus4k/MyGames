using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float m_health = 1;

    private bool m_isGettingDamage = false;
    private bool m_isDead = false;

    private HealthBar m_healthBar;
   
    private void Start()
    {
        m_healthBar = gameObject.GetComponent<HealthBar>();
    }

    public void GetDamage()
    {
        m_isGettingDamage = true;
        if (m_health > 0)
        {
            m_health -= 0.005f;
            m_healthBar.SetHealth(m_health);
        }
    }

    public void Heal()
    {
        m_isGettingDamage = false;
        StartCoroutine(Yeld(1f));
    }

    IEnumerator Yeld(float time)
    {
        yield return new WaitForSeconds(time);
        if (!m_isGettingDamage)
        {
            m_health += 0.001f;
            m_healthBar.SetHealth(m_health);

            if (m_health < 1)
            {
                StartCoroutine(Yeld(0.001f));
            }
        }  
    }

    
}
