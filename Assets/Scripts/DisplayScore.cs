using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    private int score;
    private float startTime;
    private float currentTime;

    public AchievementsController achievementsObject;
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        startTime = Time.time;
        currentTime = Time.time;
        score = 0;
    }
    public float getCurrentTime()
    {
        return Time.time - startTime;
    }
    public int getScore()
    {
        return score;
    }

    void Awake()
    {
        //If text hasn't been assigned, disable ourselves
        if (scoreText == null)
        {
            Debug.Log("You must assign a scoreText component!");
            this.enabled = false;
            return;
        }
        UpdateText(score);
        if (timeText == null)
        {
            Debug.Log("You must assign a timeText component!");
            this.enabled = false;
            return;
        }
        UpdateText(score);
    }
    public void addScore()
    {
        score += 1;
        UpdateText(score);
    }
    void UpdateText(int value)
    {
        //Update the text shown in the text component by setting the `text` variable
        scoreText.text = "Score: " + value;
    }
    private void Update()
    {
        updateTimer();
    }
    void updateTimer()
    {
        currentTime = Time.time - startTime;
        if (currentTime < 60)
        {
            if (currentTime < 10)
                timeText.text = "0:0" + (int)(currentTime);
            else
                timeText.text = "0:" + (int)(currentTime);
        }
        else
        {
            if (currentTime % 60 < 10)
                timeText.text = (int)(currentTime / 60) + ":0" + (int)(currentTime % 60);
            else
                timeText.text = (int)(currentTime / 60) + ":" + (int)(currentTime % 60);
        }

        
    }
}