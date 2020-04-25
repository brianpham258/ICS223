using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject iguanaPrefab;
    private GameObject enemy;
    private GameObject iguana;
    private GameObject[] enemies;
    private GameObject[] iguanas;
    private int numEnemy = 5;
    private int numIguana = 10;


    private void Start()
    {
        enemies = new GameObject[numEnemy];
        iguanas = new GameObject[numIguana];
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy prefab
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(i - 2, 0, 5);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
                enemies[i] = enemy;
            }
        }

        // Iguana prefab
        for (int j = 0; j < iguanas.Length; j++)
        {
            if (iguanas[j] == null)
            {
                iguana = Instantiate(iguanaPrefab) as GameObject;
                iguana.transform.position = new Vector3(j, 0, -20);
                float angle = Random.Range(0, 360);
                iguana.transform.Rotate(0, angle, 0);
                iguanas[j] = iguana;
            }
        }
    }
}
