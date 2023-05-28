using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource fx;
    public AudioClip clickFx;

    public void HoverSound()
    {
        return;
    }

    public void ClickSound()
    {
        fx.PlayOneShot(clickFx);
    }
}
