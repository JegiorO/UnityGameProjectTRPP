using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Feather : MonoBehaviour
{
    public GameObject feather;
    private GameObject player;
    public GameObject blob;
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
        if (saveManager.getTotalDeaths() >= 100)
        {
            transform.Find("FeatherSprite").gameObject.GetComponent<SpriteRenderer>().sprite = goldenSprite;
        }

        player = GameObject.FindWithTag("Player");
        feather = gameObject;
        //feather.transform.position = player.transform.position;
        pos = feather.transform.position;
        needToDraw = false;
    }

    void Update()
    {

        //������� "����������" ��������� �� ����� ����� � ������
        feather.transform.position = Vector3.Lerp(transform.position, pos + new Vector2(0, 0.16f), smoothing * Time.deltaTime);//   ������ ���������� ����
        if (feather.transform.position == new Vector3(pos.x, pos.y + 0.16f) && needToDraw) //   ���� ���� �� ������� � ���� ������� ���������� - ������
        {
            Anim.Play("FeatherDrop");

            Destroy(Instantiate(blob, pos, Quaternion.identity), lifeExpancy);
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
