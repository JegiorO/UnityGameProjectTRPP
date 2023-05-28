using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaController : MonoBehaviour
{
    public GameObject AlphaObject;
    public Image AlphaImage;
    private bool isRed;
    private void Start()
    {
        AlphaImage = AlphaObject.GetComponent<Image>();
        isRed = false;
    }
    public void activate()
    {
        AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b);
        isRed = true;
    }
    private void Update()
    {
        if (isRed)
        {
            AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a - 3f * Time.deltaTime);
            if (AlphaImage.color.a <= 0.0f)
            {
                isRed = false;
            }
        }
    }
}
