using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour
{
    [SerializeField] GameObject _c4Prefab;
    private bool _c4Placed;
    private DetonateC4 _activeC4;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //left click
        if (Input.GetButtonDown("Fire1") && _c4Placed == false)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo, 1.0f))
            {
                _c4Placed = true;
                GameObject go = Instantiate(_c4Prefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                _activeC4 = go.transform.GetComponent<DetonateC4>();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && _c4Placed == true)
        {
            
            _activeC4.Detonate();
        }

        
    }
}
