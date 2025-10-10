using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed;
    private float horizontalInput;
   
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");//Capturamos movimiento horizontal
        transform.Rotate(Vector3.up*horizontalInput * rotateSpeed *Time.deltaTime);
    }
}
