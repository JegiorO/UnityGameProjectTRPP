using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Blob : MonoBehaviour
{
    public Sprite[] sprites;
    public Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer.sprite = defaultSprite;
        }

        setSprite();
    }

    public void setSprite()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rubberContact();
        }
    }

    void rubberContact()
    {
        if (!player.isDead)
            player.playDeath();
    }
}
