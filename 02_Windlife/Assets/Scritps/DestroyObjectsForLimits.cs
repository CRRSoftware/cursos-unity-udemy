using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsForLimits : MonoBehaviour
{
    // Start is called before the first frame update
    private float fronteraSuperior=30f;
    private float fronteraInferior = -30f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > fronteraSuperior) 
        {
            Destroy(gameObject); //Borrar proyectil
        }

        if (transform.position.z < fronteraInferior)
        {
            Debug.Log("FIN DE LA PARTIDA");
            Time.timeScale = 0; //Parar el tiempo
            Destroy(gameObject); //Borrar enemigo
        }


    }
}
