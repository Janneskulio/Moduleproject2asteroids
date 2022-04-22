using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody2D movement;
    [SerializeField] float nopeus = 30.0f;
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 sijainti;
    [SerializeField] GameObject activatetext;
    [SerializeField] float raindroptime = 10.0f;
    [SerializeField] Text score;
    

    void Start()
    {
        activatetext.SetActive(false);
    }

    void FixedUpdate()
    {   
        
        float move_x = Input.GetAxis("Horizontal");
        float move_y = Input.GetAxis("Vertical");
        movement.constraints = RigidbodyConstraints2D.FreezePosition;
        movement.constraints = RigidbodyConstraints2D.FreezeRotation;
       

        if(move_y > 0)
        {
            movement.constraints = RigidbodyConstraints2D.None;
            movement.AddForce(Vector3.up * nopeus * Time.deltaTime);
            movement.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
       
        if(move_x > 0)
        {
            movement.constraints = RigidbodyConstraints2D.None;
            movement.AddForce(Vector3.right * nopeus * Time.deltaTime);
            movement.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
       
        if(move_x < 0)
        {
            movement.constraints = RigidbodyConstraints2D.None;
            movement.AddForce (Vector3.left * nopeus * Time.deltaTime);
            movement.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        if(move_y < 0)
        {
            movement.constraints = RigidbodyConstraints2D.None;
            movement.AddForce (Vector3.down * nopeus * Time.deltaTime);
            movement.constraints = RigidbodyConstraints2D.FreezeRotation;
        }      
    }    
     void OnTriggerEnter2D(Collider2D other) 
    {
     GameObject toher = other.gameObject;
        if(toher.tag == "meteori")
        {
            Destroy(Player);
        }
        if (toher.tag == "enemyprojectile")
        {
            Destroy(Player);
        }
        if(toher.tag == "raindrop")
        {
            raindroptime = 10.0f;
            Debug.Log("ok");
            activatetext.SetActive(true);
            raindroptime -= 1 * Time.deltaTime;
            Destroy(toher);
            
            if (raindroptime <= 0)
            {
                activatetext.SetActive(false);
            }
            
        }
        if(toher.tag == "earthquake")
        {
            Destroy(Player);
        }
     
    }
        

}
