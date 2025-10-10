using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 offset = new Vector3(0,5,-6); //Para poner la camara bien situada respecto al player

    private void Update()
    {
        //Poner la camara donde este el Player
        transform.position = player.transform.position + offset;
    }
}
