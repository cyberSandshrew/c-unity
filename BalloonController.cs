using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{     //sets hp
    public int clicksToPop = 3;
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;

    private Vector3 startPos;
    private bool movingToStart;

    void OnMouseDown()
    {   //subtracts 1 hp
        clicksToPop--;
        //increases scale
        transform.localScale += new Vector3(1, 1, 1);
        // pops balloon if clicks = 0
        if(clicksToPop == 0)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {  // balloons move up and to the left
        //transform.localPosition += new Vector3(0, .003f, .002f);

        //moves to start position
        if (movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            if (transform.position == startPos)
            {
                movingToStart = false;
            }
        }//moves away from start
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * moveDistance), speed * Time.deltaTime);

            if (transform.position == startPos + (moveDirection * moveDistance))
            {
                movingToStart = true;
            }
        }
    }
}
