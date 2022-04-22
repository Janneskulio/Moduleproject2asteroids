using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Rigidbody2D enemybody;
    [SerializeField] float enemyspeed = 0.0f;
    
    void Start()
    {
      
    }
    void spawnenemies(Vector3 direction)
    {
        var rotation = new Vector3(90.0f,-90.0f, 0.0f);
        var spawnipaikka = new Vector3 (0.0f, 8.0f, 0.0f);
        GameObject enemyspawning = Instantiate(enemy, spawnipaikka, Quaternion.identity);
        enemybody = enemyspawning.GetComponent<Rigidbody2D>();
        enemybody.AddForce(direction * enemyspeed);
        enemyspawning.transform.Rotate(rotation);
        Destroy(enemyspawning, 5);
    }
    void FixedUpdate()
    {
        

        if(Score.instance.score % 100 == 0 && Score.instance.score > 0
        && Score.instance.EnemyScorehold != Score.instance.score)
        {
            Score.instance.EnemyScorehold = Score.instance.score;
            var kohta = new Vector3(-2.0f, -1.0f, 0.0f);
            var kohta2 = new Vector3(2.0f, -1.0f, 0.0f);
            //var kohta3 = new Vector3(7.0f, -1.0f, 0.0f);
            spawnenemies(kohta);
            spawnenemies(kohta2);
            //spawnenemies(kohta3);
        }
    }
   
}
