using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CalculateGame : MonoBehaviour
{
    public static CalculateGame instance;
    public GameObject MainGame;
    public GameObject EndPanel;
    public TextMeshProUGUI Question;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI YourScore;
    public TextMeshProUGUI LastBestScore;
    public TextMeshProUGUI LastYourScore;
    public TMP_InputField answerInput;

    int result;
    public int score = 0;
    int bestScore;

    public int NumBestScore { get => NumBestScore; }
    public const string NumBestScoreKey = "NumBestScore";

    public bool isInput = false; // 입력했는지 확인하기 위한 불값

    public Coroutine CheckCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt(NumBestScoreKey, 0);
        BestScore.text = bestScore.ToString();
        answerInput.ActivateInputField();
        CheckCoroutine = StartCoroutine(QuestionRepeat());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!string.IsNullOrEmpty(answerInput.text))
            {
                CheckAnswer();
            }
        }
    }

    public void Calcurate() // 랜덤한 숫자 및 부호 결정
    {
        int a = 0;
        int b = 0;
        char giho = ' ';
        a = Random.Range(1, 101);
        b = Random.Range(1, 101);

        int num_1 = Random.Range(0, 4);
        switch(num_1)
        {
            case 0:
                 result = a + b;
                giho = '+';
                break;
            case 1:
                result = a - b;
                giho = '-';
                break;
            case 2:
                result = a * b;
                giho = '*';
                break;
            case 3:
                result = a / b;
                giho = '/';
                break;
            default:
                Debug.LogError("적합한 숫자가 없습니다.");
                break;
        }
        Question.text = $"{a}   {giho}   {b}   =   ?";
    }

    private void CheckAnswer()
    {
        int answer;

        if (int.TryParse(answerInput.text, out answer)) // 입력한 값을 int형식으로 변경해서 값을 비교
        {
            if (answer == result)
            {
                score += 1;
                YourScore.text = score.ToString();
                if(score > bestScore)
                {
                    bestScore = score;
                    PlayerPrefs.SetInt(NumBestScoreKey, bestScore);
                    BestScore.text = bestScore.ToString();
                }
                isInput = true;
                answerInput.text = "";
                answerInput.ActivateInputField();
                if(CheckCoroutine != null)
                {
                    StopCoroutine(CheckCoroutine);
                }
                CheckCoroutine = StartCoroutine(QuestionRepeat());
            }
            else
            {
                if (CheckCoroutine != null)
                {
                    StopCoroutine(CheckCoroutine);
                }
                GameOver();
            }
        }
    }

    public IEnumerator QuestionRepeat() // 문제가 5초마다 등장하고 문제를 맞추면 바로 문제가 바뀌게끔 설정 처음에 invoke를 활용했지만 문제를 맞추면 바로 문제가 바뀌는 것이 힘들어 코루틴으로 교체
    {
        Calcurate();

        float endTime = 5f;
        float plusTime = 0f;
        isInput = false;

        while(plusTime < endTime)
        {
            if (isInput)
            {
                yield break;
            }
            plusTime += Time.deltaTime;
            yield return null;
        }
        GameOver();
    }

    public void GameOver()
    {
        
        result = 0;
        answerInput.text = "";
        answerInput.ActivateInputField();

        if (CheckCoroutine != null)
        {
            StopCoroutine(CheckCoroutine);
        }

        EndPanel.SetActive(true);
        LastBestScore.text = bestScore.ToString();
        LastYourScore.text = score.ToString();
        MainGame.SetActive(false);
        
    }
}
