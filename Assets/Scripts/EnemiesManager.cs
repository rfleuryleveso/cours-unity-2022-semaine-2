using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int enemiesCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.enemiesCount; i++)
        {
            float angle = Mathf.PI * 2.0f * Random.Range(0.001f, 1f);
            int distance = Random.Range(10, 20);
            Instantiate(this.enemyPrefab,
                transform.position + new Vector3(Mathf.Cos(angle) * distance , 0,Mathf.Sin(angle) * distance),
                Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}