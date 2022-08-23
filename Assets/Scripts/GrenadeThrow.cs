using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    [SerializeField] float throwforce = 40f;
    [SerializeField] GameObject grenadePrefab;
    
    

    
   
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowGrenade();
        }

       
        void ThrowGrenade()
        {
            GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwforce, ForceMode.VelocityChange);
            
            

        }



    }
}
