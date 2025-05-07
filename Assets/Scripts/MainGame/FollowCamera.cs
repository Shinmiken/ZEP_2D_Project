using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Target;
    void Start()
    {
        if (Target == null) return;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target == null) return;

        Vector3 pos = transform.position;
        Vector3 targetPos = Target.position;
        pos.x = Mathf.Clamp(targetPos.x, -34.8f, 38.8f); // 카메라 움직임 제한
        pos.y = Mathf.Clamp(targetPos.y, -12f, 7.7f);
        
        transform.position = pos;

    }
}
