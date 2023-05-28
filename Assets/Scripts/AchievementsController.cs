using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementsController : MonoBehaviour //achievements and records
{
    public SaveManager saveManager;
    public Sprite[] achievementSprites;
    public Sprite defaultSprite;
    public GameObject spriteObject;
    private Animator animator;

    private Player player;
    private DisplayScore displayScore;
    public AudioSource soundUnlocked;

    public bool isUnlocked(int id)
    {
        if (saveManager.getAchievements()[id-1].Equals('1')) return true;
        return false;
    }
    private void Start()
    {
        player = FindObjectOfType<Player>();
        displayScore = player.GetComponent<DisplayScore>();
        animator = GetComponent<Animator>();
    }
    public void unlockAchievement(int id)
    {
        soundUnlocked.Play();
        Debug.Log("Achievement Unlocked. (id = "+ id+ ")");
        playAnimation(id-1);
        string ns = saveManager.getAchievements();
        ns = ns.Remove(id-1, 1).Insert(id-1, "1");
        saveManager.updateData(ns, -1, -1, false);
    }

    /*      if (!achievementsController.isUnlocked(1))
     *          {
     *              if (*unlocking condition*)
     *                  achievementsController.unlockAchievement(1);
     *          }
     */

    private void playAnimation(int id)
    {
        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;

        if (achievementSprites[id] != null)
            spriteRenderer.sprite = achievementSprites[id];

        animator.Play("AchievementAnimation", -1, 0f);
    }

    private void Update()
    {
        float currentTime = displayScore.getCurrentTime();
        int score = displayScore.getScore();

        if (!isUnlocked(1))
        {
            if (score >= 50)
                unlockAchievement(1);
        }
        if (!isUnlocked(2))
        {
            if (score >= 100)
                unlockAchievement(2);
        }
        if (!isUnlocked(3))
        {
            if (score >= 150)
                unlockAchievement(3);
        }

        if (currentTime >= 210 && currentTime < 215) // so that not to call achievementUnlock checker every update after 4 minutes, instead just make one more comparison and cgange their order
        {
            if (!isUnlocked(4))
            {
                unlockAchievement(4);
            }
        }

        if (!isUnlocked(5))
        {
            if (player.isDead && player.ds.getCurrentTime() < 1)
                unlockAchievement(5);
        }

        //achievement 5 in Player/playDeath
        //achievements 6-7 in menu achiev. controller

        if (!isUnlocked(8))
        {
            if (currentTime >= 90 && score == 0)
                unlockAchievement(8);
        }

        if (!isUnlocked(9))
        {
            if (currentTime >= 30 && !player.playerHasMoved())
            {
                unlockAchievement(9);
                Debug.Log(currentTime);
            }
        }


        if (score > saveManager.getMaxScores())
        {
            saveManager.updateData("-", -1, score, false);
        }
    }
}
