using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SetActiveManager : MonoBehaviour
{
    public GameObject ExplainText;
    public GameObject EndPanel;
    public GameObject ReStart;

    CalculateGame CalculateGame;

    private void Start()
    {
        CalculateGame = CalculateGame.instance;
    }

    public void StartGame()
    {
        ExplainText.SetActive(false);
        ReStart.SetActive(true);
    }

    public void NumReStart()
    {
        ReStart.SetActive(true);

        CalculateGame.score = 0;
        CalculateGame.YourScore.text = CalculateGame.score.ToString();
        CalculateGame.CheckCoroutine = StartCoroutine(CalculateGame.QuestionRepeat());
        EndPanel.SetActive(false);
        
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
