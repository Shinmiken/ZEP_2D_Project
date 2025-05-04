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

    private string NpcQuestion = "����� �����ϼ���^^ (������ Ŭ������)";
    private string firstAnswer = ".... �׳� �ȳ����Դϴ�^^";
    private string secondAnswer = "����� ZEP�� ��Ƽ����� �����Դϴ�. ���� ����� ������ ���ٰ�����^^";
    private float delay = 0.05f;

    public bool isSpeak; // NPC�� �پ��ִ��� üũ
    private bool isDoing = false; //NPCó�� ��� ����ϰ��ִ��� üũ

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

    IEnumerator ShowQuestion(string str) //���� �ϳ��� �����ϰ� �ϱ�
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
