using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGameManager : MonoBehaviour
{
    public GameObject numberImage;
    public GameObject StartPage;
    public GameObject ExplainPage;
    public Sprite[] NumberImages;

    void Start()
    {
        InvokeRepeating("MakeNumber", 0f, 0.1f);    
    }

    private void MakeNumber()
    {
        //위치 조정
        float x = Random.Range(-8, 8);
        float y = Random.Range(-4, 4);
        Vector3 pos = numberImage.transform.position;
        pos = new Vector3(x, y);
        numberImage.transform.position = pos;

        //숫자 종류 변경
        GameObject number = Instantiate(numberImage, this.transform);
        SpriteRenderer renderer = numberImage.GetComponent<SpriteRenderer>();
        int choice = Random.Range(0, 10);
        renderer.sprite = NumberImages[choice];

        StartCoroutine(Hiding(number));
    }

    IEnumerator Hiding(GameObject gameobject)
    {
        SpriteRenderer renderer = gameobject.GetComponent<SpriteRenderer>();
        float delay = 0.05f;
        float show = 0.15f;
        while (show < 1)
        {
            renderer.color = new Color(1, 1, 1, show);
            yield return new WaitForSeconds(delay);
            show += show;
        }
        while(show > 0)
        {
            show -= 0.15f;
            renderer.color = new Color(1, 1, 1, show);
            yield return new WaitForSeconds(delay);
        }

        Destroy(gameobject);
    }

    public void StartButton()
    {
        StartPage.SetActive(false);
        ExplainPage.SetActive(true);
        CancelInvoke("MakeNumber");
    }
}
