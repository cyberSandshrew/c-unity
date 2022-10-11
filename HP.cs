
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float Health = 10f;
     
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "projectile")
        {
            Health -= 1;
        }
        

        if (Health <= 0) 
        { 
            Destroy(gameObject); 
        }
            
    }

   
}
