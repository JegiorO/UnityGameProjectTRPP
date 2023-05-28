using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//called on deathScreen
public class goldAchieve : MonoBehaviour //achievements and records
{
    public SaveManager saveManager;
    public Sprite[] achievementSprites;
    public Sprite defaultSprite;
    public GameObject spriteObject;
    private Animator animator;
    public AudioSource unlock;

    string achieves;

    private void Start()
    {
        animator = GetComponent<Animator>();
        achieves = PlayerPrefs.GetString("gold");

        string newAchiev = "";
        Debug.Log(achieves);
        if (achieves[0] == '0')
        {
            if (saveManager.getTotalScores() >= 1000)
            {
                unlock.Play();
                playAnimation(0);
                newAchiev += "1";
            }
            else newAchiev += "0";
        }
        else newAchiev += "1";


        if (achieves[1] == '0')
        {
            if (saveManager.getTotalDeaths() >= 100)
            {
                unlock.Play();
                playAnimation(1);
                newAchiev += "1";
            }
            else newAchiev += "0";
        }
        else newAchiev += "1";

        PlayerPrefs.SetString("gold", newAchiev);
    }

    private void playAnimation(int id)
    {
        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;

        if (achievementSprites[id] != null)
            spriteRenderer.sprite = achievementSprites[id];

        animator.Play("AchievementAnimation", -1, 0f);
    }
}
