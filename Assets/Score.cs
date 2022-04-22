using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int EnemyScorehold = 0;
    public int BossScorehold = 0;
    public int EarthquakeScoreHold = 0;
    public int score = 0;
    [SerializeField] Text scoretext;
    void Start()
    {
        if (instance != null)
        {
            instance.gameObject.SetActive(false);   
        }  
        instance = this; 
    }
    public void addScore(int AddToScore)
    {
        score += AddToScore;
        scoretext.text = $"Score: {score}";
    }
    void Update()
    {
        
    }
}
