using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Sprite[] sprites;
    public Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;
    private Camera cam;
    private Player player;

    public GameObject FloatingTextPrefab;

    private bool isCollected;

    private void Start()
    {
        isCollected = false;
        cam = FindObjectOfType<Camera>();
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
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length-1)];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.gameObject.tag == "Player")
        {
            rubberContact();
        }
    }

    void rubberContact()
    {
        isCollected=true;
        player.collected.Play();
        if (FloatingTextPrefab)
        {
            Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        }
        player.addScore();
        this.spriteRenderer.enabled = false;
        Destroy(gameObject, 1.2f);
    }
}
