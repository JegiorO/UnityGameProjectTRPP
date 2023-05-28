using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class AchievementsUI : MonoBehaviour
{
    public SaveManager saveManager;
    public TextMeshProUGUI textTotal;
    public AchievementsControllerMenu achievementsController;

    public Sprite goldSkull;    //ffdwfiafgS
    public GameObject Icon;     //ffdwfiafgS
    public void updateInfo()
    {
        if (!achievementsController.isUnlocked(10))
        {
            if (saveManager.getAchievements() == "1111111110")
                achievementsController.unlockAchievement(10);
        }

        if (achievementsController.isUnlocked(10)) // for fucking designer with fucking ideas about fucking golden SHIT . ( `~`)
        {
            Icon.GetComponent<SpriteRenderer>().sprite = goldSkull;
        }


        string a = saveManager.getAchievements();

        for (int i = 0; i < 10; i++)
        {
            string name = "Achievement" + (i+1).ToString();

            GameObject child = gameObject.transform.Find(name).gameObject;
            if (a[i] == '0')
            {
                child.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
                child.GetComponent<SpriteRenderer>().enabled = false;
                
        }

        string time;
        float timeSave = saveManager.getMaxTime();
        if (timeSave < 60)
        {
            if (timeSave < 10)
                time = "0:0" + (int)(timeSave);
            else
                time = "0:" + (int)(timeSave);
        }
        else
        {
            if (timeSave % 60 < 10)
                time = (int)(timeSave / 60) + ":0" + (int)(timeSave % 60);
            else
                time = (int)(timeSave / 60) + ":" + (int)(timeSave % 60);
        }
        textTotal.text = "Total deaths:\n" + saveManager.getTotalDeaths() + "\n\nTotal scores:\n" + saveManager.getTotalScores() +
                         "\n\nMax score:\n" + saveManager.getMaxScores() + "\n\nmax time:\n" + time;
    }


}
