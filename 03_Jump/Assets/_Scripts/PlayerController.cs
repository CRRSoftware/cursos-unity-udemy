using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))] //Obliga a añadir un RB en el unity
public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    [SerializeField]
    private float jumpForce = 10;
    [SerializeField]
    private float gravityMultiplier;//Valor de la gravedad
    private bool isGround=true;//variable que cambia si se esta tocando el suelo

    private bool gameOver=false; //Normalmente se establece en el GameManager

    //GETTER Y SETTERS
    public bool getGameOver { get => gameOver; } //Para acceder desde otros scripts

    //ANIMACIONES
    private Animator _animator;
    const string speedMulti = "SpeedMulti";
    const string speed_f = "Speed_f";
    const string jump_trig = "Jump_trig";
    const string death_b = "Death_b";
    const string deathType_int = "DeathType_int";

    //PARTICULAS
    public ParticleSystem explosionParticle, runParticle;

    //SONIDOS
    public AudioClip jumpSound, dieSound;

    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>(); //Cargar el RB del player
        Physics.gravity = gravityMultiplier *new Vector3(0,-9.81f,0); //Modifica la gravedad por si queremos cambiarla (1 es normal)
        _animator = GetComponent<Animator>();
        _animator.SetFloat(speed_f, 1); //Setea un valor a la variable del Animator

        _audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        //Time.time es el tiempo que ha pasado desde que arranca el juego
        if (_animator.GetFloat(speedMulti) < 2) //SpeedMulti hace que cada vez vaya mas rapido
            _animator.SetFloat(speedMulti, 1+Time.deltaTime / 6); //Setea un valor a la variable del Animator

        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            runParticle.Stop();//Parar las particulas
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Comprobar la masa del RB del player en unity
            isGround=false;
            _animator.SetTrigger(jump_trig); //Al ser trigger, solo con llamarlo se activa

            //Sonido salto
            _audioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision -> objeto con el que choca, en este caso el suelo(ground)
        if (collision.gameObject.CompareTag("Ground"))
        {  //Comparo con el TAG del suelo
            isGround = true;
            if (!gameOver)
                runParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) //Comparo con el obstaculo
        {
            Debug.Log("GAME OVER");
            //Animacion de muerte
            _animator.SetBool(death_b, true);
            _animator.SetInteger(deathType_int, Random.Range(1, 3)); //Random porque hay 2 animaciones de muerte

            //Particula
            explosionParticle.Play();
            runParticle.Stop();
            gameOver = true;

            //Sonido muerte
            _audioSource.PlayOneShot(dieSound);

            Invoke("RestartGame", 1f);
        }
    }

    public void RestartGame()
    {
        //SceneManager.UnloadSceneAsync("Prototype 3");//Destruir la escena
        SceneManager.LoadScene("Prototype 3",LoadSceneMode.Single);//Recarga la escena
    }
}
