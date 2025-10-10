using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 spawnPosition;
    [SerializeField]
    private float spawnTime=2; //Tiempo de cortesia hasta que empieza
    [SerializeField]
    private float spawnVelocity =3;//Tiempo en que cada vez se ejecuta el metodo

    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        InvokeRepeating("SpawnObstacle", spawnTime, spawnVelocity);

        //Usamos FindWithTag o Find. Hay varios mas
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (!_playerController.getGameOver)
        {
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)]; //Elige aleatoriamente entre el array
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        }
    }

    
}
