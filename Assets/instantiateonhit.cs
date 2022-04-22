using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateonhit : MonoBehaviour
{
    [SerializeField] GameObject meteori;
    [SerializeField] Rigidbody2D meteoribody;
    [SerializeField] float meteorisped = 0.0f;
    GameObject meteoriklooni;
    void Start()
    {
        
    }
    void meteorispawning(Vector3 direction)
    {
        Vector3 kohta = transform.position;
        meteoriklooni = Instantiate(meteori, kohta, Quaternion.identity);
        meteoribody = meteoriklooni.GetComponent<Rigidbody2D>();
        meteoribody.AddForce(direction * meteorisped);
        Destroy(meteoriklooni, 2);
        meteoriklooni.GetComponent<Collider2D>().enabled = true;        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       GameObject joku = other.gameObject;
       if(joku.tag == "laser")
       {
           var suunta1 = new Vector3(1.0f,-1.0f,0.0f);
           var suunta2 = new Vector3(-1.0f,-1.0f,0.0f);
           meteorispawning(suunta1);
           meteorispawning(suunta2);   
       }
    }
    void Update()
    {
        
    }
}
