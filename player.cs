using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Jerry French 2021

public class player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpforce;

    public int score;
    private bool isGrounded;
    public UI ui;
    public float MouseSpeed = 2f;
    // Update is called once per frame
    void Update()
    {
        //mouse move
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSpeed);
        // movement inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;


        //set velocity based on input
        rig.velocity = new Vector3(x, rig.velocity.y, z);
        //create copy of velocity variable and set y axis to 0
        Vector3 vel = rig.velocity;
        vel.y = 0;
        // only rotate if we are moveing
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }
        // makes space bar jump and checks if standing on ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
        // calls game over from falling
        if(transform.position.y < -10)
        {
            GameOver();
        }


    }

    // checks if grounded
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }
    // relods scene on game over
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }//adds to score
    public void AddScore(int amount)
    {
        score += amount;
        ui.SetScoreText(score);
    }
}
