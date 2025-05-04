using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNumberGame : MonoBehaviour
{
    public GameObject NumberGameObject;
    public GameObject NumberDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NumberGameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NumberGameObject.SetActive(false);
        }
    }
}
