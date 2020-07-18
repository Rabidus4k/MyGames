using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Spawner : MonoBehaviour
{
    public Enemy[] arrayOfEnemiesModels;
    private GameObject[] arrayOfEnemies = new GameObject[Enum.enemiesToSpawn];

    public Text text;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(Speed());

        for (int i = 0; i < arrayOfEnemies.Length; i++)
        {
            Vector3 spawnPos = new Vector3();
            spawnPos.z = Random.Range(player.transform.position.z - 100, player.transform.position.z + 100);
            spawnPos.x = Random.Range(player.transform.position.x, transform.position.x);

            arrayOfEnemies[i] = Instantiate(arrayOfEnemiesModels[Random.Range(0, arrayOfEnemiesModels.Length)].gameObject, spawnPos, Quaternion.Euler(0f, Random.Range(0,360), 0f));
        }
    }

    public void NewGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < arrayOfEnemies.Length; i++)
        {
            Vector3 spawnPos = new Vector3();
            spawnPos.z = Random.Range(player.transform.position.z - 100, player.transform.position.z + 100);
            spawnPos.x = Random.Range(player.transform.position.x, transform.position.x);

            arrayOfEnemies[i].transform.position = spawnPos;
        }
    }

    public static void Respawn(GameObject gm)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");

        Vector3 spawnPos = new Vector3();

        spawnPos.x = spawner.transform.position.x;
        spawnPos.y = spawner.transform.position.y;
        spawnPos.z = Random.Range(player.transform.position.z - 100, player.transform.position.z + 100);

        gm.transform.position = spawnPos;
    }

    IEnumerator Speed()
    {
        yield return new WaitForSeconds(.1f);
        Enum.score++;
        text.text = Enum.score.ToString();
        if (Enum.score % 50 == 0)
        {
            Enum.globalSpeed += 1;   
        }        
        StartCoroutine(Speed());
    }
}
