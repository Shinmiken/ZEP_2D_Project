using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManger : MonoBehaviour
{
    public static UiManger instancee;
    public Transform target;
    public Transform GameOverUI;
    public Transform GameOverBackUI;

    public GameObject gameObject;
    Vector3 pos = Vector3.zero;
    Vector3 backPos = Vector3.zero;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI NowText;
    public TextMeshProUGUI BestScpre;

    private int currentScore;
    private int bestScore;

    public int BestScore { get => BestScore; }

    private const string BestScoreKey = "BestScore";

    private void Awake()
    {
        if (instancee == null)
        {
            instancee = this;
        }
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey,0);
    }

    public void GameOver()
    {
        if (FlapPlayer.instance.isDead)
        {
            pos = GameOverUI.transform.position;
            pos.x = target.position.x;
            GameOverUI.transform.position = pos;
            backPos = GameOverBackUI.transform.position;
            backPos.x = target.position.x;
            GameOverBackUI.position = backPos;
            NowText.text = currentScore.ToString();
            BestScpre.text = bestScore.ToString();
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                PlayerPrefs.SetInt(BestScoreKey, bestScore);
            }
            FlapPlayer.instance.ScoreUI.SetActive(false);
            gameObject.SetActive(true);
        }
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene("FlapScene");
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public int AddScore(int score)
    {
        currentScore += score;
        return currentScore;
    }
}
