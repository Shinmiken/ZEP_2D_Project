using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlapRock : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    public float wildth = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPosition, float count)
    {
        float topholeSize = Random.Range(-2.2f, -1.5f);
        float botholeHole = Random.Range(1.9f, 2.4f);

        top.localPosition = new Vector3 (0, botholeHole);
        bottom.localPosition = new Vector3 (0, topholeSize);

        Vector3 pos = lastPosition + new Vector3(wildth, 0);
        transform.position = pos;
        return pos;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlapPlayer player = collision.GetComponent<FlapPlayer>();
        if (player != null )
        {
            UiManger.instancee.UpdateScore(UiManger.instancee.AddScore(1));
        }
    }
}
