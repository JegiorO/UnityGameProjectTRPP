using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathBackground : MonoBehaviour
{
    public Sprite[] sprites;
    void Start()
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }
}
