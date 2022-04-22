using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laserprojectile : MonoBehaviour
{
    public Text nytscore;
    public GameObject acticationtext;
    public Rigidbody2D raindrop;
    void Start()
    {
        
    }

   
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject toher = other.gameObject;
        if(toher.tag == "meteori")
        {            
            Debug.Log("toimiko");
            Destroy(toher);
            Destroy(gameObject);
            Score.instance.addScore(10);                   
        }
        if(toher.tag == "raindrop")
        {
            acticationtext.SetActive(true);   
        }
        if(toher.tag == "enemy")
        {
            Destroy(toher);
            Destroy(gameObject);
            Score.instance.addScore(20); 
        }
         if(toher.tag == "seinä")
        {
            Destroy(gameObject);
        }
    }
  
    void Update()
    {
    }
}
