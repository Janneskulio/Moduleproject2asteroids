using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscontroller : MonoBehaviour
{
    [SerializeField] Rigidbody2D bossbody;
    
    [SerializeField] float bossAbilityusage1 = 0.0f;
    [SerializeField] float bossAbility1cd = 0.0f;
    [SerializeField] GameObject BossProjectile;
    [SerializeField] Rigidbody2D BossProjectileBody;
    [SerializeField] float BossProjectileSpeed = 0.0f;
    [SerializeField] GameObject bossLaser;
    [SerializeField] Rigidbody2D bossLaserBody;
    [SerializeField] float bosslaserspeed = 0.0f;
    [SerializeField] float bossAbility2cd = 0.0f;
    [SerializeField] float bossSpeeding = 1.0f;
    [SerializeField] Vector3 direction1 = new Vector3 (0.5f,-1.0f,0.0f);
    [SerializeField] Vector3 direction2 = new Vector3(-0.5f,-1.0f,0.0f);
    [SerializeField] Vector3 direction3 = new Vector3(0.2f,-1.0f,0.0f);
    [SerializeField] Vector3 direction4 = new Vector3(-0.2f,-1.0f,0.0f);
    [SerializeField] Vector3 direction5 = new Vector3(0.8f,-1.0f,0.0f);
    [SerializeField] Vector3 direction6 = new Vector3(-0.8f,-1.0f,0.0f);
    [SerializeField] Vector3 direction7 = new Vector3(1.1f,-1.0f,0.0f);
    [SerializeField] Vector3 direction8 = new Vector3(-1.1f,-1.0f,0.0f);
    [SerializeField] Vector3 direction9 = new Vector3(0.0f,-1.0f,0.0f);
    [SerializeField] Vector3 direction10 = new Vector3(0.0f,-1.0f,0.0f);
    [SerializeField] Vector3 direction11 = new Vector3(-0.3f,-1.0f,0.0f);
    [SerializeField] Vector3 direction12 = new Vector3(0.3f,-1.0f,0.0f);





    
    void Start()
    {
        bossAbilityusage1 = 0;
        bossAbility1cd = 0;
        bossAbility2cd = 0;
    }
    void BossProjectileShooting1(Vector3 direction)
    {
        Vector3 location = transform.position;
        GameObject bossShooting = Instantiate(BossProjectile, location,Quaternion.identity);
        BossProjectileBody = bossShooting.GetComponent<Rigidbody2D>();
        BossProjectileBody.AddForce(direction * BossProjectileSpeed);

        Destroy(bossShooting, 2.5f);
    }
    void enemylaserspawning(Vector3 laserdir)
    {
        Vector3 location = transform.position;
        GameObject bosslasershooting = Instantiate(bossLaser, location, Quaternion.identity);
        bossLaserBody = bosslasershooting.GetComponent<Rigidbody2D>();
        bossLaserBody.AddForce(laserdir*bosslaserspeed);
        //bossLaserBody.transform.rotation = Quaternion.LookRotation(laserdir);
        Destroy(bosslasershooting, 4);
    }
    void FixedUpdate()
    {
        bossbody.AddForce(Vector2.zero);
        bossAbilityusage1 += 1 * Time.fixedDeltaTime;
        bossAbility1cd += 1 * Time.fixedDeltaTime;
        bossAbility2cd += 1 * Time.fixedDeltaTime;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        GameObject jokunen = other.gameObject;
        Debug.Log(bossAbilityusage1);

        if(jokunen.tag == "enemyshoot")
        {
            
            //bossbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            
            if(bossAbilityusage1 >= 2)
            {
                if(bossAbility1cd >= 0.5f)
                {
                    Debug.Log(bossAbility1cd); 
                    BossProjectileShooting1(direction1);
                    BossProjectileShooting1(direction2);
                    BossProjectileShooting1(direction3);
                    BossProjectileShooting1(direction4);
                    BossProjectileShooting1(direction5);
                    BossProjectileShooting1(direction6);                
                    bossAbility1cd = 0.1f;
                }
            }
            if(bossAbilityusage1 >= 2)
            {
                if(bossAbility2cd >= 1)
                {
                    enemylaserspawning(direction10);
                    enemylaserspawning(direction11);
                    enemylaserspawning(direction12);
                    bossAbility2cd = 0;
                }
            }
            if(bossAbilityusage1 >= 10)
            {
                bossbody.AddForce(Vector2.left * bossSpeeding);
            }
            if(bossAbilityusage1 >= 13)
            {
                bossbody.constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }        
        
    }   
}
