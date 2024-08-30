using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using DG.Tweening;

public class Quiz : MonoBehaviour
{
    public static int currentLevel;
    public static int correctCount;

    [SerializeField] private float _timeLimit;

    [SerializeField] private TextMeshProUGUI[] _optionTexts;
    [SerializeField] private SpriteRenderer[] _quizBackgrounds;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Player _player;

    private float _currentTime;
    private bool isStart;

    public QuizSOList quizSOList;
    private List<QuizSO> _quizList = new List<QuizSO>();
    private QuizSO _quiz;

    private void Awake()
    {
        currentLevel = 0;
        correctCount = 0;

        for (int i = 0; i < 4; i++)
        {
            _quizBackgrounds[i]
                = GameObject.Find($"Option{i + 1}").GetComponent<SpriteRenderer>();
        }

        foreach (QuizSO quizSO in quizSOList.list)
        {
            _quizList.Add(quizSO);
        }

        InitializeQuiz();
    }

    private void Update()
    {
        if (isStart)
        {
            _currentTime += Time.deltaTime;
            _timerText.text = (_timeLimit - _currentTime).ToString("F2");
            TimerCheck();
        }
    }

    private void InitializeQuiz()
    {
        _quiz = _quizList[currentLevel];
        _player.transform.position = new Vector3(0, 0, 0);
        _currentTime = 0;

        for (int i = 0; i < 4; i++)
        {
            _optionTexts[i].text = _quiz.optionText[i];
            _quizBackgrounds[i].color = Color.white;
        }
        _title.text = _quiz.titleText;

        isStart = true;
    }

    private void CheckAnswer()
    {
        if (_player._selected == _quiz.correctIndex)
        {
            correctCount++;
        }

        for (int i = 0; i < 4; i++)
        {
            if (i + 1 != _quiz.correctIndex)
                _quizBackgrounds[i].DOColor(Color.red, 0.5f);
            else
                _quizBackgrounds[i].DOColor(Color.green, 0.5f);
        }

        StartCoroutine(IntervalQuiz());
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

    private IEnumerator IntervalQuiz()
    {
        yield return new WaitForSeconds(5f);
        currentLevel++;
        InitializeQuiz();
    }
}
