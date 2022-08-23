using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] float radius = 5f;
    [SerializeField] float force = 700f;
    

    float countdown;
     bool hasExploded = false;
   
    void Start()
    {
        countdown = delay;
    }

    
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            
            Explode();
            hasExploded = true;
            
        }
    }

    void Explode()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }


        
        Destroy(gameObject);
        
        
    }
}
