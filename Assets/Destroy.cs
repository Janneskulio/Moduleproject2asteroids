using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 4);
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject joku = other.gameObject;
        if(joku.tag =="Player")
        {
            Destroy(joku);
        }
    }
}
