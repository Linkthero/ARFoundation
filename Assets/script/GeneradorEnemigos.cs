using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    //array de enemigos
    public GameObject[] enemies;

    //tiempo q pasa para spawnear
    public float timeSpawn = 1;

    //se crea un enemigo cada x seg
    private float repeatSpawnRate;

    [SerializeField] public Transform xRangeLeft;
    [SerializeField] public Transform xRangeRight;

    [SerializeField] public Transform yRangeUp;
    [SerializeField] public Transform yRangeDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        repeatSpawnRate = (float)UnityEngine.Random.Range(5, 10);
        //StartCoroutine(Example());
        InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
    }

    public void SpawnEnemies()
    {
            //posicion donde se crea, aleatoria
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(xRangeLeft.position.x, xRangeRight.position.x), UnityEngine.Random.Range(yRangeDown.position.y, yRangeUp.position.y), UnityEngine.Random.Range(yRangeDown.position.z, yRangeUp.position.z));

            int numEnemigo = UnityEngine.Random.Range(0, enemies.Length);
            Quaternion rotacion = gameObject.transform.rotation;
        rotacion.y = rotacion.y + 180;
        GameObject enemie = Instantiate(enemies[numEnemigo], spawnPosition, rotacion);
    }
}
