using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField]
    private float speed=10f;
    [SerializeField]
    private float xRange = 15.5f; //Rango del limite de la camara
    [SerializeField]
    private GameObject projectile; //Se arrastra el proyectil-prefabs


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput*Time.deltaTime);

        //Mantener el player en la zona de la camara
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        //Detectar disparo
        if (Input.GetKeyDown(KeyCode.Space)) //o Input.GetAxis("Fire")
        {
            //Lanzar un proyectil(instanciar el gameObject)
            Instantiate(projectile,transform.position,projectile.transform.rotation);
        }
    }

}
