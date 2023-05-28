using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public TextMeshProUGUI resultsText;
    public void back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            retry();
        }
    }

    private void Start()
    {
        LastPlayInfo lastPlayInfo = GameObject.FindObjectOfType<LastPlayInfo>();
        int score = lastPlayInfo.getLastScore();
        float time = lastPlayInfo.getLastTime();
        Destroy(lastPlayInfo);


        string timeStr;
        if (time <= 60)
        {
            timeStr = "0:";
            if (time < 10) timeStr += "0";
            timeStr += time.ToString();
        }
        else
        {
            timeStr = ((int)time / 60).ToString() + ":";
            if (time % 60 < 10) timeStr += "0";
            timeStr += (time % 60).ToString();
        }
        resultsText.text = "Score: " + score + "\nTime: " + timeStr;
    }
}
