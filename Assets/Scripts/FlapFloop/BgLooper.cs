using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    private float rockCount;
    private Vector2 rockPosition = Vector2.zero;

    void Start()
    {
        FlapRock[] flapRock = GameObject.FindObjectsOfType<FlapRock>();
        rockPosition = flapRock[0].transform.position;
        rockCount = flapRock.Length;
        for (int i = 0; i < flapRock.Length; i++)
        {
            rockPosition = flapRock[i].SetRandomPlace(rockPosition, rockCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BoxCollider2D box = collision as BoxCollider2D;
        if (collision.CompareTag("BackGround"))
        {
            if (box != null)
            {
                float backGroundSize = box.size.x;
                Vector3 sizeVec = collision.transform.position;
                sizeVec.x += backGroundSize * 5;
                collision.transform.position = sizeVec;
                return;
            }
        }

        FlapRock flapRock = collision.GetComponent<FlapRock>();

        if (flapRock)
        {
            rockPosition = flapRock.SetRandomPlace(rockPosition, rockCount);
        }
    }
}
