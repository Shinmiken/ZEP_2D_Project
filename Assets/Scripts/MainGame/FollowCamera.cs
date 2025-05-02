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
        pos.x = Mathf.Clamp(targetPos.x, -8.8f, 7.7f);
        pos.y = Mathf.Clamp(targetPos.y, -14, 12.3f);
        
        transform.position = pos;

    }
}
