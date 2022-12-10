using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    // The player object that the object will move towards
    public Transform player;

    // The speed at which the object will move
    public float speed = 1.0f;

    void Update()
    {
        // Calculate the direction from the object to the player
        Vector3 direction = player.position - transform.position;

        // Normalize the direction so that it has a magnitude of 1
        direction.Normalize();

        // Move the object in the direction of the player at the specified speed
        transform.position += direction * speed * Time.deltaTime;

        // Check if the object is colliding with the player
        if (CheckCollisionWithPlayer())
        {
            // Stop the object's movement if it is colliding with the player
            transform.position = transform.position;
        }
    }

    bool CheckCollisionWithPlayer()
    {
        // Calculate the distance between the object and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the distance is less than the sum of the object's and player's collider radii
        if (distance < (GetComponent<SphereCollider>().radius + player.GetComponent<SphereCollider>().radius))
        {
            return true;
        }
        return false;
    }
}
