using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapFollwCamera : MonoBehaviour
{
    public Transform target;

    Vector3 moveVec;

    void Update() // ī�޶� ������
    {
        moveVec = transform.position;
        moveVec.x = target.position.x;
        transform.position = moveVec;
    }
}
