using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Pen pen;
    public Feather feather;
    public Player player;
    private DisplayScore displayScore;
    public float startLifeExpancy;
    public float startsmoothing;

    private float featherSpawnInterval, penSpawnInterval;

    private float featherPrevTime, penPrevTime;

    void Awake()
    { 
        displayScore = player.ds;
        featherPrevTime = 0;
        penPrevTime = 0;
        featherSpawnInterval = 2.7f;
        penSpawnInterval = 2.5f;

        feather.smoothing = startsmoothing;
        pen.smoothing = startsmoothing;
        feather.lifeExpancy = startLifeExpancy;
        pen.lifeExpancy = startLifeExpancy;
    }

    void Update()
    {
        //if (Time.time - prevTime > spawnInterval && !feather.needToDraw)
        //{
        //    callFeather();
        //    callPen();

        //    float d;
        //    if (displayScore.getCurrentTime() < 60)
        //        d = 0.02f;
        //    else if (displayScore.getCurrentTime() < 120)
        //        d = 0.05f;
        //    else d = 0.1f;

        //    spawnInterval = Mathf.Abs(spawnInterval - d);
        //    increaseSmoothing(0.2f);
        //    leasenlifeExpancy(0.05f);

        //    prevTime = Time.time;
        //}

        if (Time.time - featherPrevTime > featherSpawnInterval && !feather.needToDraw)
        {
            callFeather();

            float curTime = displayScore.getCurrentTime();
            float d;

            if (curTime < 60)
                d = Random.Range(0.03f, 0.05f);
            else if (curTime < 100)
                d = Random.Range(0f, 0.003f);
            else if (curTime < 120)
                d = Random.Range(0.06f, 0.08f);
            else if (curTime < 140)
                d = Random.Range(0f, 0.003f);
            else if (curTime < 180)
                d = Random.Range(0.01f, 0.03f);
            else d = Random.Range(0.005f, 0.01f); 

            featherSpawnInterval = Mathf.Abs(featherSpawnInterval - d);

            featherPrevTime = Time.time;
        }

        if (Time.time - penPrevTime > penSpawnInterval && !pen.needToDraw)
        {
            callPen();

            float curTime = displayScore.getCurrentTime();
            float d;

            if (curTime < 60)
                d = Random.Range(0.03f, 0.05f);
            else if (curTime < 100)
                d = Random.Range(0f, 0.003f);
            else if (curTime < 120)
                d = Random.Range(0.06f, 0.08f);
            else if (curTime < 140)
                d = Random.Range(0f, 0.003f);
            else if (curTime < 180)
                d = Random.Range(0.01f, 0.02f);
            else d = Random.Range(-0.1f, 0.15f);

            penSpawnInterval = Mathf.Abs(penSpawnInterval - d);
            increaseSmoothing(0.1f);
            leasenlifeExpancy(0.05f);

            penPrevTime = Time.time;
        }
    }

    void callPen()
    {
        pen.SpawnDrawing();
    }
    void callFeather()
    {
        feather.SpawnDrawing();
    }
    void increaseSmoothing(float value)
    {
        feather.smoothing += value;
        pen.smoothing += value;
    }
    void leasenlifeExpancy (float value)
    {
        //feather.lifeExpancy += value; //אנלאדוההמם .
        if (pen.lifeExpancy > 2.5f)
        {
            pen.lifeExpancy -= value;
        }

        if (displayScore.getCurrentTime() > 180 && feather.lifeExpancy < 7.5f)
            feather.lifeExpancy += value;
    }
}
