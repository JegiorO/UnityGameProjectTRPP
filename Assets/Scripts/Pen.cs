using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Pen : MonoBehaviour
{
    private GameObject pen;
    private GameObject player;
    public GameObject drawing;
    public Animation Anim;
    public SaveManager saveManager;
    public Sprite goldenSprite;

    private Vector2 center; // ����� �������� � ������� ����� ���������� ������� (������ � ������� ��� ������� ������)
    public bool needToDraw;
    private Vector2 pos;

    public float lifeExpancy;
    public float smoothing; //  ��� ������ Lerp'�, ����� ��� "��������"
    public Vector2 SpawnSize; // ������� �������� � ������� ��������� �������

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pen = gameObject;
        pos = pen.transform.position;
        needToDraw = false;

        Debug.Log(saveManager.getTotalScores());
        if (saveManager.getTotalScores() >= 1000)
        {
            GetComponent<SpriteRenderer>().sprite = goldenSprite;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
            SpawnDrawing();

        //������� "����������" ��������� �� ����� ����� � ������
        pen.transform.position = Vector3.Lerp(transform.position, pos + new Vector2(0, 0.16f), smoothing * Time.deltaTime);//   ������ ���������� pen
        if (pen.transform.position == new Vector3(pos.x, pos.y + 0.16f) && needToDraw) //   ���� �������� �� ������� � ���� ������� ���������� - ������
        {
            Anim.Play("PenDraw");

            Destroy(Instantiate(drawing, pos, Quaternion.identity), lifeExpancy);
            needToDraw = false;
        }
    }

    public void SpawnDrawing() //������ ����� �������
    {
        center = new Vector2(0, 0);
        pos = center + new Vector2(UnityEngine.Random.Range(-SpawnSize.x / 2, SpawnSize.x / 2), UnityEngine.Random.Range(-SpawnSize.y / 2, SpawnSize.y / 2));

        needToDraw = true;
    }
}
