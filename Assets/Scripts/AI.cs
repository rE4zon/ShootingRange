using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private float timer;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            Player = col.gameObject;
            gameObject.GetComponent<Animator>().SetBool("fire", true);
            transform.LookAt(col.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            onFire();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("fire", false);
        }
    }
    void onFire()
    {
        
        timer += 1 * Time.deltaTime;
        if(timer >=1.2f)
        {
            Player.GetComponent<HealthPlayer>().Health -= 24;
            timer = 0;
            
        }
    }
}
