using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs; //Si lo haces lista GameObject[] puedes añadir varios enemigos
    private float spawnRange = 9;
    [SerializeField]
    private int numOfEnemies;
    [SerializeField]
    private int numOfWaves = 1;

    [SerializeField]
    private GameObject powerUpPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(numOfWaves);//Generar oleada de enemigos
    }

    void Update()
    {
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length; //Obtengo el nº de enemigos que quedan vivos

        //Si me quedo sin enemigos, creo uno nuevo
        if (numOfEnemies == 0)
        {
            numOfWaves++;
            SpawnEnemyWave(numOfWaves);

            Instantiate(powerUpPrefabs, GenerateSpawnPosition(),powerUpPrefabs.transform.rotation);//Crea powerUps
        }
    }

    /// <summary>
    /// Generar oleada de enemigos
    /// </summary>
    private void SpawnEnemyWave(int numOfEnemies)
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            //Aleatoriedad en el spawn
            Vector3 randowPos = GenerateSpawnPosition();
            Instantiate(enemyPrefabs, randowPos, enemyPrefabs.transform.rotation); //Instanciar enemigo
        }
    }

    /// <summary>
    /// Aleatoriedad en el objeto gameObject spawnManager
    /// </summary>
    /// <returns></returns>
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randowPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randowPos;
    } 

    
}
