using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeValue : MonoBehaviour
{
    public Slider soundSlider, musicSlider;
    public SaveManager saveManager;
    public AudioMixer am;
    public AchievementsControllerMenu achievementsController;

    private void Start()
    {
        setDefault();
    }

    public void setDefault()
    {
        soundSlider.value = PlayerPrefs.GetFloat("Sound");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        am.SetFloat("sfxVol", PlayerPrefs.GetFloat("Sound"));
        am.SetFloat("musicVol", PlayerPrefs.GetFloat("Music"));
    }
    public void SetSfxLvl(float sfxLvl)
    {
        am.SetFloat("sfxVol", sfxLvl);
        PlayerPrefs.SetFloat("Sound", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        am.SetFloat("musicVol", musicLvl);
        PlayerPrefs.SetFloat("Music", musicLvl);
    }

    private void Update()
    {
        if (soundSlider.value <= -60 && musicSlider.value <= -60)
        {
            if (!achievementsController.isUnlocked(7))
            {
                achievementsController.unlockAchievement(7);
            }
        }
    }
}
