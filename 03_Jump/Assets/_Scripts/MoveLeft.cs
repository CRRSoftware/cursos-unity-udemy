using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private PlayerController _playerController;


    private void Start()
    {
        //Usamos FindWithTag o Find. Hay varios mas
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!_playerController.getGameOver)
             transform.Translate(Vector3.left*speed*Time.deltaTime);
    }

    /// <summary>
    /// Destruye los barriles
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
          if (other.CompareTag("LimitDestroy"))
            Destroy(this.gameObject);
    }
}
