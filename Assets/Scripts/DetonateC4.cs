using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonateC4 : MonoBehaviour
{
    [SerializeField] GameObject _explisionPrefab;
    

    public void Detonate()
    {
        Instantiate(_explisionPrefab, transform.position, Quaternion.identity);
        
        Destroy(this.gameObject);
    }
}
