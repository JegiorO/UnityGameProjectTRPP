using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowAchievementInfo : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] int id;

    void Start()
    {
        text.SetActive(false);
    }

    public void OnMouseOver()
    {
        setText();
        text.SetActive(true);
    }

    public void OnMouseExit()
    {
        text.SetActive(false);
    }

    void setText()
    {
        string t;
        switch (id)
        {
            case 1:
                t = "gain 50";
                break;
            case 2:
                t = "gain 100";
                break;
            case 3:
                t = "gain 150";
                break;
            case 4:
                t = "survive for 3:30";
                break;
            case 5:
                t = "speedrun the life";
                break;
            case 6:
                t = "click something in menu";
                break;
            case 7:
                t = "tshh!";
                break;
            case 8:
                t = "how to gain scores here?";
                break;
            case 9:
                t = "dont touch anything!";
                break;
            case 10:
                t = "the master eraser.";
                break;
            default:
                t = "";
                break;
        }
        text.GetComponent<TextMeshProUGUI>().text = t;
    }
}
