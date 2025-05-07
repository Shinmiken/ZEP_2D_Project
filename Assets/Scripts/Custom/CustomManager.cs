using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    public GameObject CustomStartUI;
    public GameObject CustomUI;


    private bool isOpen = false;

    public void ShowCustom() // 커스텀 화면 보여주기
    {
        isOpen = true;
        CustomStartUI.SetActive(false);
        CustomUI.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision) // 커스텀 문과 충돌하면 UI등장
    {
        if (!isOpen)
        CustomStartUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision) // UI 제거
    {
        CustomStartUI.SetActive(false);
    }

    public void ExitCustom() 
    {
        CustomUI.SetActive(false);
        isOpen = false;
    }
}
