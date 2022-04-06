using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public bool hooked;

    public float MouseSpeed = 2f;

    public GameObject projectile;
    public float launchVelocity = 700f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                GameObject ball = Instantiate(projectile, transform.position, transform.rotation);

                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
            }
        }

        
        //transform.Rotate(Vector3.right * Input.GetAxis("Mouse Y") * MouseSpeed);

    }

    
}
