using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapFollwCamera : MonoBehaviour
{
    public Transform target;

    Vector3 moveVec;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVec = transform.position;
        moveVec.x = target.position.x;
        transform.position = moveVec;
    }
}
