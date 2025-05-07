using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBoard : MonoBehaviour
{
    public Sprite[] spriteOption;
    public GameObject imageGameObject;

    private void Start() // 각 스킨들을 화면에 표시
    {
        float x = -150;
        float y = 0;
        for (int i = 0; i < spriteOption.Length; i++)
        {
            GameObject go = Instantiate(imageGameObject, this.transform);
            
            
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(x, y);
            x += 100;
            if (x == 250)
            {
                x = -150;
                y -= 70;
            }
            Image image = go.GetComponent<Image>();
            image.sprite = spriteOption[i];
        }
    }
}
