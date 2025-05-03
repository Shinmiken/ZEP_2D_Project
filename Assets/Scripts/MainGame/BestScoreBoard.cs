using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class BestScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI FlappyScore;
    public GameObject scoreObject;

    float bestScore;
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void ShowScoreBoard()
    {
        scoreObject.SetActive(true);
        FlappyScore.text = bestScore.ToString();
    }

    public void ExitBoard()
    {
        scoreObject.SetActive(false);
    }
}
