using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    public Transform target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 rot = target.rotation.eulerAngles; // 카메라 뒤집기
            if (rot.z == 0)
            {
                rot.z = 180;
            }
            else
            {
                rot.z = 0;
            }
            target.rotation = Quaternion.Euler(rot);
        }
    }
}
