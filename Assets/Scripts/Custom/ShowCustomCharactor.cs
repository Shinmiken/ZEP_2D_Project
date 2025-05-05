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

    public void TakeImage() // 플레이어 이미지 및 색깔 가져오기
    {
        SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
        image.sprite = spriteRenderer.sprite;
        image.color = spriteRenderer.color;
    }
}
