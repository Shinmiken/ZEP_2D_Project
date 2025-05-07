using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    public GameObject CustomStartUI;
    public GameObject CustomUI;


    private bool isOpen = false;

    public void ShowCustom() // Ŀ���� ȭ�� �����ֱ�
    {
        isOpen = true;
        CustomStartUI.SetActive(false);
        CustomUI.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision) // Ŀ���� ���� �浹�ϸ� UI����
    {
        if (!isOpen)
        CustomStartUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision) // UI ����
    {
        CustomStartUI.SetActive(false);
    }

    public void ExitCustom() 
    {
        CustomUI.SetActive(false);
        isOpen = false;
    }
}
