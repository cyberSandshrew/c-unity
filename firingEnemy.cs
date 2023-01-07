using UnityEngine;

public class firingEnemy : MonoBehaviour
{
    // The player object that the enemy will target
    public Transform player;

    // The speed at which the enemy will move
    public float speed = 1.0f;

    

    // The distance at which the enemy will start moving towards the player
    public float detectionRange = 10.0f;

    

    

    

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

    
}


