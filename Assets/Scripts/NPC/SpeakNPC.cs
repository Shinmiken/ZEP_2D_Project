using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpeakNPC : MonoBehaviour
{
    public GameObject NpcBalloon;
    public GameObject NPCSPEAK;
    public GameObject Introdution;
    public GameObject ScoreUI;
    public TextMeshProUGUI InText;

    private Coroutine DoCorotine;

    private string NpcQuestion = "모든지 질문하세요^^ (질문을 클릭하자)";
    private string firstAnswer = ".... 그냥 안내꾼입니다^^";
    private string secondAnswer = "여기는 ZEP을 모티브로한 공간입니다. 여러 기능이 있으니 즐기다가세요^^";
    private float delay = 0.05f;

    public bool isSpeak; // NPC와 붙어있는지 체크
    private bool isDoing = false; //NPC처음 대사 출력하고있는지 체크

    private void Update()
    {
        if (isSpeak && Input.GetKeyDown(KeyCode.F) && !isDoing)
        {
            ScoreUI.SetActive(false);
            NPCSPEAK.SetActive(true);
            NpcBalloon.SetActive(true);
            DoCorotine = StartCoroutine(ShowQuestion(NpcQuestion));
        }
    }

    IEnumerator ShowQuestion(string str) //문장 하나씩 등장하게 하기
    {
        isDoing = true;
        InText.text = "??? : ";
        foreach (char letter in str)
        {
            InText.text += letter;
            yield return new WaitForSeconds(delay);
        }
        
        isDoing=false;
    }

    public void FirstQestion()
    {
        NPCSPEAK.SetActive(false);
        DoCorotine = StartCoroutine(ShowQuestion(firstAnswer));
    }

    public void SecondQestion()
    {
        NPCSPEAK.SetActive(false);
        DoCorotine = StartCoroutine(ShowQuestion(secondAnswer));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Introdution.SetActive(true);
            isSpeak = true;   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(DoCorotine != null)
            {
                StopCoroutine(DoCorotine);
                isDoing = false;
            }
            isSpeak = false;
            ScoreUI.SetActive(true);
            Introdution.SetActive(false);
            NpcBalloon.SetActive(false);
            if(NPCSPEAK != null)
            {
                NPCSPEAK.SetActive(false);
            }
        }
    }
}
