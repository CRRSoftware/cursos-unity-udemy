using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField, Range(2, 5)]
    private float startDelay = 2f; //2 segundos de cortesia cuando arranque el juego
    [SerializeField, Range(1, 5)]
    private float spawnInterval = 1.5f; //Cada cuantos segundos se genera un enemigo

    private int enemiesIndex;
    private float spawnRangeX = 14f; //Limite en X de donde aparecen los enemigos
    private float spawnPositionZ;    

    private void Start()
    {
        spawnPositionZ = transform.position.z; //Guarda la position Z donde esta el manager, el cual no cambia

        //Invoca la funcion cada vez que se cumple un intervalo de tiempo
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    /// <summary>
    /// Genera un enemigo aleatorio en una posicion aleatoria.
    /// Se llama con el InvokeRepeating
    /// </summary>
    private void SpawnRandomEnemy()
    {
        //Generar la posicion donde aparecera el proximo enemigo. La X es nº aleatorio spawnRangeX
        float xRandom = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(xRandom, 0, spawnPositionZ);

        enemiesIndex = Random.Range(0, enemies.Length); //Genera la aleatoriedad

        Instantiate(enemies[enemiesIndex], spawnPosition, enemies[enemiesIndex].transform.rotation);
        Debug.Log("Creado enemigo:" + enemies[enemiesIndex].name);
    }


}
