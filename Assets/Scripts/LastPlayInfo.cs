using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastPlayInfo : MonoBehaviour
{
    private int score;
    private float time;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
            Destroy(this);
        DontDestroyOnLoad(this);

        Debug.Log(score + " " + time);
    }


    public void updateInfo(int a, float b)
    {
        score = a;
        time = b;
    }

    public int getLastScore()
    {
        return score;
    }
    public float getLastTime()
    {
        return time;
    }
}
