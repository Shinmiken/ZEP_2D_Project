using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class BestScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI FlappyScore;
    public TextMeshProUGUI NumberScore;
    public GameObject scoreObject;

    float bestScore;
    int numberScore;
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        numberScore = PlayerPrefs.GetInt("NumBestScore", 0);
    }

    public void ShowScoreBoard()
    {
        scoreObject.SetActive(true);
        FlappyScore.text = bestScore.ToString();
        NumberScore.text = numberScore.ToString();
    }

    public void ExitBoard()
    {
        scoreObject.SetActive(false);
    }
}
