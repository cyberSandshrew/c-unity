using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;

    private Vector3 startPos;
    private bool movingToStart;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            if(transform.position == startPos)
            {
                movingToStart = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * moveDistance), speed * Time.deltaTime);

            if(transform.position == startPos + (moveDirection * moveDistance))
            {
                movingToStart = true;
            }
        }
    }
        //sets trigger to collider
    private void OnTriggerEnter(Collider other)
    {
        //checks if tagged as player
        if(other.CompareTag("Player"))
        {
            // calls gameover frome player script
            other.GetComponent<player>().GameOver();
        }
    }
}
