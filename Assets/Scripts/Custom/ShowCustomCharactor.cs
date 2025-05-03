using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCustomCharactor : MonoBehaviour
{
    public Image image;
    public GameObject GameObject;

    private void Update()
    {
        TakeImage();
    }

    public void TakeImage()
    {
        SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
        image.sprite = spriteRenderer.sprite;
        image.color = spriteRenderer.color;
    }

    public void ChangeImage()
    {
        SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = image.sprite;
    }
}
