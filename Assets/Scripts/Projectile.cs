using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    [SerializeField] float radius = 3f;
    public int damageAmount = 15;
    private void OnCollisionEnter(Collision collision)
    {
        
        GameObject impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(impact, 2);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            if(nearbyObject.tag == "Player")
            {
                HealthPlayer.TakeDamage(damageAmount);
            }
        }
        Destroy(gameObject);
    }
}
