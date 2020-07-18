using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    private static float hp;
    private static bool dead = false;
    private Transform bar;

    void Start()
    {
        bar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Transform>();
        hp = 1f;
    }

    void Update()
    {
        checkHp();
        if (dead)
        {
            //SceneManager.LoadScene("Death");
        }
    }

    void checkHp()
    {
        bar.localScale = new Vector3(hp, 1f);
        if (hp >= 100)
        {
            hp = 99;
        }
    }


    public static void getDamage(float ammount)
    {

        if (hp <= 0)
        {
            dead = true;
        }
        else
        {
            hp -= ammount;
            //Text.text = Mathf.Round(hp).ToString();
        }
    }

    public static void increaseHp(int num)
    {
        hp += num;
    }
}
