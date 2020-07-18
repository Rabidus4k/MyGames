using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    // Start is called before the first frame update
    public int width = 10;
    public int height = 10;
    public int depth = 10;

    public float minThreshold = 0.4f;
    public float maxThreshold = 0.6f;
    public float noiseDevider = 25f;


    public GameObject cubePref;

    private bool[,,] array;

    private void Start()
    {
        GenerateLevel();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RegenerateLevel();
        }
    }

    private void RegenerateLevel()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach(var obj in cubes)
        {
            Destroy(obj);
        }

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        array = new bool[depth, height, width];

        for (int k = 0; k < depth; k++)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    float x = j / noiseDevider;
                    float y = i / noiseDevider;
                    float z = k / noiseDevider;

                    float perlin = GeneratePerlin3D(x, y, z);

                    if (perlin > minThreshold && perlin < maxThreshold)
                    {
                        array[k, i, j] = true;
                    }
                }
            }
        }

        for (int k = 0; k < depth; k++)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (k - 1 >= 0 && i - 1 >= 0 && j - 1 >=0 && k + 1 < depth && i + 1 < height && j + 1 < width)
                    {
                        if (!(array[k - 1 ,i ,j] && array[k + 1, i, j] && array[k, i - 1, j] && array[k, i + 1, j] && array[k, i, j - 1] && array[k, i, j + 1]))
                        {
                            Instantiate(cubePref, new Vector3(k, i, j), Quaternion.identity);
                        }
                    }
                }
            }
        }
    }

    private float GeneratePerlin3D(float x, float y, float z)
    {
        float AB = Mathf.PerlinNoise(x, y);
        float BC = Mathf.PerlinNoise(y, z);
        float AC = Mathf.PerlinNoise(x, z);

        float BA = Mathf.PerlinNoise(y, x);
        float CB = Mathf.PerlinNoise(z, y);
        float CA = Mathf.PerlinNoise(z, x);

        float ABC = AB + BC + AC + BA + CB + CA;

        return ABC / 6f; 
    }
}
