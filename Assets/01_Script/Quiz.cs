using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    public static int currentLevel;

    [SerializeField] private float _timeLimit;
    [SerializeField] private int[] correctIndex;

    [SerializeField] private TextMeshProUGUI[] _optionTexts;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _timerText;

    private float _currentTime;
    private bool isStart;

    private QuizSOList _quizListSO;
    private List<QuizSO> _quizList;
    private QuizSO _quiz;

    private void Awake()
    {
        foreach (QuizSO quizSO in _quizListSO.list)
        {
            _quizList.Add(quizSO);
        }

        Initialize();
    }

    private void Update()
    {
        if (isStart)
        {
            _currentTime += Time.deltaTime;
            TimerCheck();
        }
    }

    private void Initialize()
    {
        currentLevel = 0;
        _quiz = _quizList[currentLevel];

        for (int i = 0; i < 4; i++)
        {
            _optionTexts[i].text = _quiz.optionText[i];
        }
        _title.text = _quiz.titleText;

        isStart = true;
    }

    private void CheckAnswer()
    {

    }

    private void TimerCheck()
    {
        if (_currentTime > _timeLimit)
        {
            isStart = false;
            _currentTime = 0;

            CheckAnswer();
        }
    }
}
