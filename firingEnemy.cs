using UnityEngine;

public class firingEnemy : MonoBehaviour
{
    // The player object that the enemy will target
    public Transform player;

    // The speed at which the enemy will move
    public float speed = 1.0f;

    // The projectile prefab that the enemy will launch at the player
    public GameObject projectilePrefab;

    // The distance at which the enemy will start moving towards the player
    public float detectionRange = 10.0f;

    // The distance at which the enemy will stop and start firing at the player
    public float firingRange = 5.0f;

    // The time between each shot (in seconds)
    public float fireRate = 1.0f;

    // The time when the enemy can fire again (in seconds)
    private float cooldown = 0.0f;

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the enemy's detection range
        if (distance <= detectionRange)
        {
            // Move the enemy towards the player
            MoveTowardsPlayer();

            // Check if the player is within the enemy's firing range
            if (distance <= firingRange)
            {
                // Check if the enemy's cooldown has expired
                if (cooldown <= 0.0f)
                {
                    // Launch a projectile at the player
                    LaunchProjectile();

                    // Reset the enemy's cooldown
                    cooldown = fireRate;
                }
            }
        }

        // Decrement the enemy's cooldown by the time that has passed since the last frame
        cooldown -= Time.deltaTime;
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = player.position - transform.position;

        // Normalize the direction so that it has a magnitude of 1
        direction.Normalize();

        // Move the enemy in the direction of the player at the specified speed
        transform.position += direction * speed * Time.deltaTime;
    }

    void LaunchProjectile()
    {
        // Instantiate a new projectile at the enemy's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Set the projectile's velocity so that it moves towards the player
        projectile.GetComponent<Rigidbody>().velocity = (player.position - transform.position).normalized * speed;
    }
}


