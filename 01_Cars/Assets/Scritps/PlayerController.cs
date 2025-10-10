using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField,Range(0,40),Tooltip("Velocidad del coche-player")]
    private float speed=5f;

    [SerializeField,Range(0,50)]
    private float turnSpeed=30.5f; //Velocidad de giro del volante-derecha/izquierda

    private float horizontalInput; //Mover el volante
    private float verticalInput; //Acelerar/frenar
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //Coger si es positivo o negativo
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward* speed * verticalInput*Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
    }
}
