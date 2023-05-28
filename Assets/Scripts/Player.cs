using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera _camera;
    public SpriteRenderer sr;
    public Sprite stand, moveLeft, moveRight;
    public Sprite standGold, moveLeftGold, moveRightGold;
    private Sprite st, mr, ml;
    public Sprite[] deathSprites, deathSpritesGold;
    public bool isDead;

    public SaveManager saveManager;
    public AudioSource collected;
    public AudioSource death;

    public float maxMoveSpeed = 1.0f;
    public float smoothTime = 0.3f;
    private Rigidbody2D _rb;
    public DisplayScore ds;
    public AlphaController alphaController;

    private bool hasMoved; //achievement id 9

    private bool isGold;

    public AchievementsController achievementsController;

    public LastPlayInfo lpi;
    void Start()
    {
        if (saveManager.getAchievements() == "1111111111")///////////////////////////////////////////
        {
            isGold = true;
            st = standGold;
            mr = moveRightGold;
            ml = moveLeftGold;
        }
        else
        {
            st = stand;
            isGold = false;
            mr = moveRight;
            ml = moveLeft;
        }
        hasMoved = false;
        isDead = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        if (!isDead)
        {
            Movement();
        }
    }

    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        _rb.velocity = new Vector3(x, y).normalized;

        _rb.AddForce(_rb.velocity * maxMoveSpeed);

        if (x > 0) sr.sprite = mr;
        else if (x < 0) sr.sprite = ml;
        else sr.sprite = st;

        if (x != 0 || y != 0) hasMoved = true;
    }

    public bool playerHasMoved()
    {
        return hasMoved;
    }
    public void addScore()
    {
        ds.addScore();
    }

    public void playDeath()
    {
        isDead=true;

        _camera.GetComponent<AudioSource>().Stop();

        lpi.updateInfo(ds.getScore(), ds.getCurrentTime());
        

        if (ds.getCurrentTime() > saveManager.getMaxTime())
        {
            saveManager.updateData("-", ds.getCurrentTime(), -1, false);
        }
        saveManager.increaseTotalScores(ds.getScore());

        saveManager.updateData("-", -1, -1, true);

        //›“Œ“  ”—Œ   Œƒ¿  –¿ÿ»“ »√–” . ≈—À» ”¬»ƒ»“≈ ≈√Œ Õ¿ ”À»÷≈ - ƒ¿…“≈ œŒ ≈¡¿À” œ∆ .
        //if (!achievementsController.isUnlocked(5))
        //{
        //    if (ds.getCurrentTime() < 1)
        //        achievementsController.unlockAchievement(5);
        //}

        death.Play();
        alphaController.activate();
        _rb.velocity = new Vector2(0,0);
        if (!isGold)
            StartCoroutine(playAnimationManually(deathSprites, 150));
        else
            StartCoroutine(playAnimationManually(deathSpritesGold, 150));
    }

    IEnumerator playAnimationManually(Sprite[] sprites, int delayMs)
    {
        for (int i = 0; i < sprites.Length-1; i++)
        {
            sr.sprite = sprites[i];
            yield return new WaitForSeconds((float)delayMs / 1000);
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
