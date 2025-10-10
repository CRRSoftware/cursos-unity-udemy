using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public GameObject focalPoint;
    [SerializeField]
    private bool hasPowerUp;
    [SerializeField] 
    private float powerUpForce;

    [SerializeField]
    private float moveForce;
    [SerializeField]
    private float powerUpTime;

    public GameObject[] powerUpIndicator; //Indicador de power up asignado desde Unity

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //Es mejor usar
        //focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * forwardInput,ForceMode.Force);

        foreach (GameObject indicator in powerUpIndicator)
        {
            indicator.transform.position = this.transform.position; //Lo coloca en el centro del Player
        }

        //Si el player baja de -20 se destruye + gameover
        if (this.transform.position.y < -20)
            SceneManager.LoadScene("Prototype 4");
    }

    /// <summary>
    /// Cuando choca con un powerUP
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PowerUp"))
        {
            Debug.Log("OnTriggerEnter");
            hasPowerUp = true;
            Destroy(other.gameObject);//Destruimos el objeto PowerUP
            //Posible efecto al cogerlo
            

            StartCoroutine("PowerUpCountDown");//Corrutina que espera X segundos para cancelar el efecto del PowerUP
        }
    }

    /// <summary>
    /// Cuando choca con un enemigo
    /// </summary>
    /// <param name="collision">gameObject con el que choca</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            //El enemigo saldrá disparado al chocar con nuestro Player
            Rigidbody enemyRigitBody = collision.gameObject.GetComponent<Rigidbody>(); //Obtengo el RB del enemigo
            //Obtiene la direccion donde se desplazara al enemigo
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;

            enemyRigitBody.AddForce(awayFromPlayer * powerUpForce,ForceMode.Impulse);//Aplica la fuerza
        }
    }

    /// <summary>
    /// Corrutina que espera X segundos para cancelar el efecto del PowerUP
    /// </summary>
    /// <returns></returns>
    IEnumerator PowerUpCountDown()
    {
        //Activar anillo indicador de PowerUP
        powerUpIndicator[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(powerUpTime); //Esperamos X segundos
        //Desactivar anillo indicador de PowerUP
        powerUpIndicator[0].gameObject.SetActive(false);

        hasPowerUp =false;

        
    }
}
