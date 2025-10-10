using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; //Donde esta el background
    private float widthCollider;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //Obtenemos la anchura del boxcollider del background y dividimos entre dos para saber la mitad
        widthCollider = GetComponent<BoxCollider>().size.x / 2; 
    }

    // Update is called once per frame
    void Update()
    {
         if(startPos.x- transform.position.x  > widthCollider) //Calculo que se ha movido la x -50 a la izquierda
            transform.position = startPos; //Reseteo la posicion a la inicial
    }
}
