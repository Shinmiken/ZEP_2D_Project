using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void FlappyPlane()
    {
        SceneManager.LoadScene("FlapScene");
    }

    public void NumberGame()
    {
        SceneManager.LoadScene("NumberGameScene");
    }
}
