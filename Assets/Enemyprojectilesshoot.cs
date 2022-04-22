using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyprojectilesshoot : MonoBehaviour
{
    [SerializeField] GameObject enemyProjectiles;
    [SerializeField] Rigidbody2D enemyprojectilesbody;
    [SerializeField] Rigidbody2D enemyprojectilesbody3;
    [SerializeField] float enemyprojectilespeed = 0.0f;
    [SerializeField] Rigidbody2D enemy;
    [SerializeField] float instantiatecd = 0.0f;
    Vector3 sliding2 = new Vector3(0.0f,-1.0f, 0.0f);
    Vector3 sliding3 = new Vector3(0.0f,-1.0f, 0.0f);
    Vector3 sliding4 = new Vector3(0.0f,-1.0f, 0.0f);
    void Start()
    {
        
    }
    void Update()
    {
        instantiatecd -= 1 * Time.deltaTime;
    }
    void spawnenemyprojectile(Vector3 direction)
    {
        Vector3 location = transform.position;
        GameObject enemyprojectilespawning = Instantiate(enemyProjectiles,location, Quaternion.identity);
        Rigidbody2D enemyprojectilesbody = enemyprojectilespawning.GetComponent<Rigidbody2D>();
        enemyprojectilesbody.AddForce(direction * enemyprojectilespeed);
        
    }
    void OnTriggerStay2D(Collider2D other) 
    {
        GameObject joku = other.gameObject;
        if(joku.tag == "enemyshoot")
        { 
            enemy.constraints = RigidbodyConstraints2D.FreezePosition;
            if(instantiatecd <= 0)
            {
                sliding2 -= new Vector3(-0.2f,0.0f, 0.0f);
                sliding3 -= new Vector3(0.2f,0.0f, 0.0f);
                spawnenemyprojectile(sliding2);               
                spawnenemyprojectile(sliding3);
                spawnenemyprojectile(sliding4);
                Debug.Log("shooting");
                instantiatecd = 0.080f;
                Debug.Log(instantiatecd);
            }
            
        }
        if(joku.tag =="Player")
        {
            Destroy(joku);
        }
    }
}