using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform target;
    public GameObject lizardman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 pos = lizardman.transform.position;
            pos = target.position;
            pos.y += 1;
            pos.z = lizardman.transform.position.z;
            lizardman.transform.position = pos;
            lizardman.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lizardman.SetActive(false);
        }
    }
}
