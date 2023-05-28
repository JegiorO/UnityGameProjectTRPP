using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementsControllerMenu : MonoBehaviour //achievements and records
{
    public SaveManager saveManager;
    public Sprite[] achievementSprites;
    public Sprite defaultSprite;
    public GameObject spriteObject;
    private Animator animator;
    public AudioSource unlocked;

    public bool isUnlocked(int id)
    {
        if (saveManager.getAchievements()[id - 1].Equals('1')) return true;
        return false;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void unlockAchievement(int id)
    {
        unlocked.Play();
        Debug.Log("Achievement Unlocked. (id = " + id + ")");
        playAnimation(id - 1);
        string ns = saveManager.getAchievements();
        ns = ns.Remove(id - 1, 1).Insert(id - 1, "1");
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

    public void achievement6()
    {
        if (!isUnlocked(6))
        {
            unlockAchievement(6);
        }
    }

}
