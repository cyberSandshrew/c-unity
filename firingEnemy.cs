using UnityEngine;
using System.Collections;

public class firingEnemy : MonoBehaviour
{
    // The player object that the enemy will target
    public Transform player;

    // The speed at which the enemy will move
    public float speed = 1.0f;


    // The distance at which the enemy will start moving towards the player
    public float detectionRange = 10.0f;

    public float moveDuration = 1.0f; // duration for moving the object
    public float rotationAngle = 90.0f; // angle to rotate the object
    public float rotationDuration = 1.0f; // duration for rotating the object

    private Rigidbody rb; // Rigidbody component of the object
    private bool isGrounded; // flag to check if the object is grounded

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveAndRotate());
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the enemy's detection range
        if (distance <= detectionRange)
        {
            // Move the enemy towards the player
            MoveTowardsPlayer();


        }
        else if(isGrounded)
        {
            StartCoroutine(MoveAndRotate());
        }

        // destroy from falling
        if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = player.position - transform.position;

        // Normalize the direction so that it has a magnitude of 1
        direction.Normalize();

        // Move the enemy in the direction of the player at the specified speed
        transform.position += direction * speed * Time.deltaTime;

        transform.LookAt(player.transform);

    }

    IEnumerator MoveAndRotate()
    {
        // move the object forward for the specified duration
        float elapsedTime = 0.0f;
        while (elapsedTime < moveDuration)
        {
            rb.velocity = transform.forward * speed; // move the object at a speed of 10 units per second
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // rotate the object for the specified duration
        elapsedTime = 0.0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * rotationAngle);
        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // continue moving the object forward
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        isGrounded = true;// checks if grounded
        
    }
}



