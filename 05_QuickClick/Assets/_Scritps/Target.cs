using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float minForce = 14;
    [SerializeField]
    private float maxForce = 20;

    private float minTorque = -10;
    private float maxTorque = 10;
    private float minRangeX = -4;
    private float maxRangeX = 4;
    private float rangeY = 4;

    // Start is called before the first frame update
    void Start()
    {
        //Esto empujará a los objetos hacia arriba
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        //Rotacion/Torsion
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque()
            ,ForceMode.Impulse);

        //Instanciacion dependiendo de los bordes de la pantalla. Solo la X es la aleatoria ya que es la horizontal
        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private float RandomTorque()
    {
        return Random.Range(minTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(minRangeX, maxRangeX), rangeY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
