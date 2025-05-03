using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCard : MonoBehaviour
{
    public GameObject targetGameObject;

    public void ChangeColor(float r, float g, float b)
    {
        SpriteRenderer rn = targetGameObject.GetComponent<SpriteRenderer>();
        rn.color = new Color(r, g, b);
    }

    public void Red()
    {

        float r = 255f/255f;
        float g = 0;
        float b = 0;

        ChangeColor(r, g, b);
    }

    public void Green()
    {
        float r = 0;
        float g = 255f / 255f;
        float b = 0;

        ChangeColor(r, g, b);
    }

    public void Blue()
    {
        float r = 0;
        float g = 0;
        float b = 255f / 255f;

        ChangeColor(r, g, b);
    }

    public void Black()
    {
        float r = 0;
        float g = 0;
        float b = 0;

        ChangeColor(r, g, b);
    }

    public void White()
    {
        float r = 255f / 255f;
        float g = 255f / 255f;
        float b = 255f / 255f;

        ChangeColor(r, g, b);
    }

    public void Yellow()
    {
        float r = 255f / 255f;
        float g = 255f / 255f;
        float b = 0;

        ChangeColor(r, g, b);
    }

    public void Ornage()
    {
        float r = 255f / 255f;
        float g = 128f / 255f;
        float b = 0;

        ChangeColor(r, g, b);
    }

    public void puple()
    {
        float r = 128f / 255f;
        float g = 0;
        float b = 128f / 255f;

        ChangeColor(r, g, b);
    }
}
