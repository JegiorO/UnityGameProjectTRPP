using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class REDORANGE : MonoBehaviour
{
    public AudioMixer am;
    public AudioSource redorange;
    public Slider musicSlider, soundSlider;
    private float soundsave, musicsave;
    bool isPlaying;

    void Start()
    {
        isPlaying = false;
    }


    public void play()
    {
        isPlaying=true;
        soundsave = soundSlider.value;
        musicsave = musicSlider.value;
        musicSlider.value = -80;
        soundSlider.value = 0;
        PlayerPrefs.SetFloat("Sound", soundsave);
        PlayerPrefs.SetFloat("Music", musicsave);

        am.SetFloat("musicVol", -80);
        am.SetFloat("sfxVol", 0);
        redorange.Play();
    }

    public void stop()
    {
        isPlaying=false;
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        soundSlider.value = PlayerPrefs.GetFloat("Sound");
        am.SetFloat("musicVol", PlayerPrefs.GetFloat("Music"));
        am.SetFloat("sfxVol", PlayerPrefs.GetFloat("Sound"));
        redorange.Stop();
    }

    public void button()
    {
        isPlaying = !isPlaying;
        if (isPlaying)
        {
            play();

        }
        else
            stop();
    }
}
