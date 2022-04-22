using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meterori : MonoBehaviour
{
    
    [SerializeField] GameObject meteori;
    [SerializeField] Rigidbody2D meteoribody;
    [SerializeField] float meteorisped = 0.0f;
    
    [SerializeField] float meteorispawntime = 3.0f;
    [SerializeField] GameObject projectiles;
    [SerializeField] Rigidbody2D projectilebody;
    public GameObject activationtext;
    [SerializeField] float raindroptime = 0.0f;
    [SerializeField] float raindropfalltime = 0.0f;
    [SerializeField] GameObject raindrop;
    [SerializeField] Rigidbody2D raindropbody;
    [SerializeField] float raindropspeed = 0.0f;
    Vector3 suunta = new Vector3(-0.5f, -1.0f, 0.0f);
    [SerializeField] float spawntime = 0f;
    [SerializeField] GameObject boss;
    [SerializeField] Rigidbody2D bossbody;
    [SerializeField] float bossSpeed = 0.0f;
    [SerializeField] GameObject boulder;
    [SerializeField] Rigidbody2D boulderbody;
    [SerializeField] Rigidbody2D boulderbody2;
    [SerializeField] float earthquaketime = 0.0f;
    
    void Start()
    {
        activationtext.SetActive(false); 
    }
    void earthquakespawn(Vector3 earthquakedir)
    {
        var Boulderlocation = new Vector3(23.0f,-4.7f,0.0f);
        var Boulderlocation2 = new Vector3(-23.0f,4.7f,0.0f);
        float earthquakespeed = 300.0f;
        GameObject earthquake = Instantiate(boulder,Boulderlocation,Quaternion.identity);
        GameObject earthquake2 = Instantiate(boulder,Boulderlocation2,Quaternion.identity);
        boulderbody = earthquake.GetComponent<Rigidbody2D>();
        boulderbody.AddForce(earthquakedir * earthquakespeed);
    }
    void raindropspawn(Vector3 raindropdir)
    {
        var projectilepaikka = new Vector3(8.21f, 4.44f, 0.0f);
        float projectilespeed = 300.0f;
        GameObject projectilethrow = Instantiate(projectiles, projectilepaikka, Quaternion.identity);
        projectilebody = projectilethrow.GetComponent<Rigidbody2D>();
        projectilebody.AddForce(raindropdir * projectilespeed);
        Destroy(projectilethrow, 5);
    }
   
    void Update()
    {
        
        earthquaketime -= 1 * Time.deltaTime;
        raindropfalltime -= 1 * Time.deltaTime;
        meteorispawntime -= 1 * Time.deltaTime;
        
        if(Score.instance.score % 150 == 0 && Score.instance.score > 0
        && Score.instance.EarthquakeScoreHold != Score.instance.score)
        {
            if(earthquaketime <= 0)
            {
            Score.instance.EarthquakeScoreHold = Score.instance.score;
            var earthquakesuunta = new Vector3(1.0f, 0.0f, 0.0f);
            var earthquakesuunta2 = new Vector3(-1.0f, 0.0f,0.0f);
            var Boulderlocation = new Vector3(23.0f,-4.7f,0.0f);
            var Boulderlocation2 = new Vector3(-23.0f,4.7f,0.0f);
            float earthquakespeed = 500.0f;
            GameObject earthquake = Instantiate(boulder,Boulderlocation,Quaternion.identity);
            GameObject earthquake2 = Instantiate(boulder,Boulderlocation2,Quaternion.identity);
            boulderbody = earthquake.GetComponent<Rigidbody2D>();
            boulderbody2 = earthquake2.GetComponent<Rigidbody2D>();
            boulderbody.AddForce(earthquakesuunta2 * earthquakespeed);
            boulderbody2.AddForce( earthquakesuunta * earthquakespeed);
            Destroy(earthquake, 5);
            Destroy(earthquake2, 5);
            earthquaketime = 3.0f;
            }
        }

        if(Score.instance.score % 50 == 0 && Score.instance.score > 0
        && Score.instance.BossScorehold != Score.instance.score)
        {
            Score.instance.BossScorehold = Score.instance.score;
            var bossSpawnLocation = new Vector3(0.0f,9.0f,0.0f);
            GameObject bossSpawn = Instantiate(boss, bossSpawnLocation,Quaternion.identity);
            bossbody = bossSpawn.GetComponent<Rigidbody2D>();
            bossbody.AddForce(Vector3.down * bossSpeed);
            bossSpawn.transform.Rotate(90,0,-180);
            Debug.Log("happening"); 
        
        }
        if(raindropfalltime <= 0)
        {
            GameObject raindropklooni;
            var raindroppaikka = new Vector3(Random.Range(-10.0f, 10.0f),8.0f, 0.0f );
            raindropklooni = Instantiate(raindrop, raindroppaikka, Quaternion.identity);
            raindropbody = raindropklooni.GetComponent<Rigidbody2D>();
            raindropbody.AddForce(Vector3.down * raindropspeed * Time.fixedDeltaTime);
            Destroy(raindropklooni, 4);
            raindropfalltime = 2.0f;

        }
        
        if(meteorispawntime <= 0)
        {
            GameObject meteoriklooni;
            var paikka = new Vector3(Random.Range(-10.0f, 10.0f),8.0f, 0.0f );
            meteoriklooni = Instantiate(meteori, paikka, Quaternion.identity);
            meteoribody = meteoriklooni.GetComponent<Rigidbody2D>();
            meteoribody.AddForce(Vector3.down * meteorisped * Time.fixedDeltaTime);
            Destroy(meteoriklooni, 4);
            meteorispawntime = 1.0f;            
           
        }
       
         if(activationtext.activeSelf)
        {
            spawntime -= 1 * Time.deltaTime;
            raindroptime -= 1 * Time.deltaTime;
            if(spawntime <= 0)
            {
                suunta -= new Vector3(10.0f,0.0f, 0.0f) * Time.fixedDeltaTime;
                raindropspawn(suunta);
                spawntime = 0.2f;
            }          
            if(raindroptime <= 0)
            {
                suunta = new Vector3(-0.5f, -1.0f, 0.0f);
                
                raindroptime = 1.0f;
                activationtext.SetActive(false);
            }

        }

               
    }
        
}
