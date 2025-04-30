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
        //¾ç¿·
        if(pos.x >= 37.7f)
        {
            if (pos.x >= Target.position.x)
            {
                pos.x = Target.position.x;
            }
            else
            {
                pos.x = 37.7f;
            }
        }
        else if (pos.x <= -44.7f)
        {
            if (pos.x <= Target.position.x)
            {
                pos.x = Target.position.x;
            }
            else
            {
                pos.x = -44.7f;
            }
        }
        else
        {
            pos.x = Target.position.x;
        }
        //À§¾Æ·¡
        if (pos.y >= 22.3f)
        {
            if(pos.y >= Target.position.y)
            {
                pos.y = Target.position.y;
            }
            else
            {
                pos.y = 22.3f;
            }
        }
        else if (pos.y <= -29)
        {
            if(pos.y <= Target.position.y)
            {
                pos.y = Target.position.y;
            }
            else
            {
                pos.y = -29;
            }
        }
        else
        {
            pos.y = Target.position.y;
        }
        transform.position = pos;

    }
}
