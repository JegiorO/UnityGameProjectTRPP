using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    string achievements, goldAchievements;    //00_0000_0000 - each zero is a boolean of achieve being achieved, 00 - pen and feather
    float musicVol;
    float sfxVol;
    float maxTime;         
    int maxScores;
    int totalScores;
    int totalDeaths;


    private void Awake()
    {
        LoadGame();
    }


    public float getMaxTime()
    {
        return maxTime;
    }

    public int getMaxScores()
    {
        return maxScores;
    }

    public int getTotalScores()
    {
        return totalScores;
    }

    public void increaseTotalScores(int score)
    {
        totalScores += score;
        SaveData();
    }

    public int getTotalDeaths()
    {
        return totalDeaths;
    }

    public string getAchievements()
    {
        return achievements;
    }
    /// <summary>
    /// string "-" for string and "-1" for ints in parameteres does not update following data
    /// </summary>
    public void updateData(string achievements, float maxTime, int maxScores, bool increaseDeathsCount)
    {
        if (achievements != "-") this.achievements = achievements;
        if (maxTime != -1) this.maxTime = maxTime;
        if (maxScores != -1) this.maxScores = maxScores;
        if (increaseDeathsCount) this.totalDeaths += 1;

        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("Achievements", achievements);
        PlayerPrefs.SetFloat("MaxTime", maxTime);
        PlayerPrefs.SetInt("MaxScores", maxScores);
        PlayerPrefs.SetInt("TotalDeaths", totalDeaths);
        PlayerPrefs.SetInt("TotalScores", totalScores);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Achievements"))
        {
            achievements = PlayerPrefs.GetString("Achievements");
            maxTime = PlayerPrefs.GetFloat("MaxTime");
            maxScores = PlayerPrefs.GetInt("MaxScores");
            totalDeaths = PlayerPrefs.GetInt("TotalDeaths");
            sfxVol = PlayerPrefs.GetFloat("Sound");
            musicVol = PlayerPrefs.GetFloat("Music");
            totalScores = PlayerPrefs.GetInt("TotalScores");

            Debug.Log("Game data loaded!");
            Debug.Log(achievements + " " + musicVol + " " + sfxVol + " " + totalDeaths + " " + totalScores + " "+ maxScores + " " + maxTime);
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        achievements="0000000000";
        maxTime=0;
        maxScores=0;
        totalDeaths=0;
        totalScores = 0;
        goldAchievements = "00";
        

        PlayerPrefs.SetString("Achievements", achievements);
        PlayerPrefs.SetFloat("MaxTime", maxTime);
        PlayerPrefs.SetInt("MaxScores", maxScores);
        PlayerPrefs.SetInt("TotalDeaths", totalDeaths);
        PlayerPrefs.SetInt("TotalScores", totalScores);
        PlayerPrefs.SetString("gold", goldAchievements);
        PlayerPrefs.Save();

        Debug.Log("Data reset complete");
    }

}
