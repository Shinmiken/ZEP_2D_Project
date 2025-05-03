using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakNPC : MonoBehaviour
{
    public GameObject NpcBalloon;
    public GameObject InText;
    public GameObject ScoreUI;

    public bool isSpeak;

    private void Update()
    {
        if (isSpeak && Input.GetKeyDown(KeyCode.F))
        {
            ScoreUI.SetActive(false);
            NpcBalloon.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InText.SetActive(true);
            isSpeak = true;   
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isSpeak = false;
            ScoreUI.SetActive(true);
            InText.SetActive(false);
            NpcBalloon.SetActive(false);
        }
    }
}
