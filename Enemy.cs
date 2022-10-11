using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;



public class Enemy : MonoBehaviour
{
    public int speed;

    public GameObject player;

    void Start()

    {
        //face the player
        transform.Rotate(180, 0, 0);

    }

    void Update()

    {
        // move to player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }
}

