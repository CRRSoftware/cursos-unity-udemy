using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject player; //El enemigo seguira al player
    [SerializeField]
    private float moveForce;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection =(player.transform.position - this.transform.position).normalized; //para saber la direccion del player
        _rigidbody.AddForce(lookDirection * moveForce,ForceMode.Force);

        //Si el enemigo baja de -20 Y se destruye
        if (this.transform.position.y < -20)
            Destroy(this.gameObject);
    }
}
