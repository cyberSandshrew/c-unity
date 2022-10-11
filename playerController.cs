using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    
    public Vector3 MovementDirection;
    
    public float MouseSpeed = 2f;

    public float maxSpeed = 200f;//Replace with your max speed


    public int score;
    public UI ui;

    public Rigidbody rig;
    public float jumpforce;
    private bool isGrounded;

    public float movementSpeed = 5.0f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;

    public float Health = 10f;

    // Start is called before the first frame update
    

    void Start()
    {
        //Set Cursor to not be visible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody forwards constantly at speed you define 
            //rig.velocity = transform.forward * movementSpeed;

            rig.AddForce(transform.forward * movementSpeed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(-transform.forward * movementSpeed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(-transform.right * movementSpeed, ForceMode.Force);
        }


        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(transform.right * movementSpeed, ForceMode.Force);
        }

        //set max speed
        if (rig.velocity.magnitude > maxSpeed)
        {
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }


        // camera mouse move
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSpeed);
        
        // makes space bar jump and checks if standing on ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        // calls game over from falling
        if (transform.position.y < -10)
        {
            GameOver();
        }
    }

    

    // checks if grounded
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "enemy")
        {
            Health -= 1;
        }


        if (Health <= 0)
        {
            GameOver();
        }

        //if (collision.contacts[0].normal == Vector3.up)
        //{
        isGrounded = true;
        //}
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
