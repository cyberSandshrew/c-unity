using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    public float lifetime;

    void Start()
     {
        Destroy(gameObject, lifetime);
     }
        // Start is called before the first frame update

   // private void OnTriggerEnter(Collider other)
    //{
        //Destroy(gameObject);
        
    //}
    
}

