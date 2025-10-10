using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//other-> El objeto con el que se ha chocado
    {
        if (other.CompareTag("bullet")) //bullet es una tag
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }
}
