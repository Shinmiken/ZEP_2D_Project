using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMiniGame : MonoBehaviour
{
    public GameObject FlappyGameObject;
    public GameObject FlappyDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FlappyGameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FlappyGameObject.SetActive(false);
        }
    }
}
