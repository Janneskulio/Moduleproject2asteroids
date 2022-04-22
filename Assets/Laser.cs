using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    Rigidbody2D laserinbody;
    [SerializeField] float laserinnopeus = 0.0f;
    [SerializeField] GameObject laser;
    void Start()
    {
           
    }

    void Update()
    {
       
        
        if(Input.GetButtonDown("Fire1"))
        {
            Transform liikkuuko = GetComponent<Transform>();
            Vector3 kohta = transform.position;
            GameObject laseroid;
            laseroid = Instantiate(laser,kohta, Quaternion.identity);   
            laserinbody = laseroid.GetComponent<Rigidbody2D>();
            Destroy(laseroid, 1);
            laserinbody.AddForce(Vector3.up * laserinnopeus); 
            
        }    
    }
    
}
