using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using DG.Tweening;
using UnityEngine.Events;

public class Quiz : MonoBehaviour
{
    public int currentLevel;
    public int score;

    public UnityEvent<bool> OnComplete;

    [SerializeField] private float _timeLimit;

    [SerializeField] private TextMeshProUGUI[] _optionTexts;
    [SerializeField] private SpriteRenderer[] _quizSprite;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Player _player;

    public bool isStart;
    public bool isComplete;

    private float _currentTime;

    public QuizSOList quizSOList;
    public List<QuizSO> _quizList = new List<QuizSO>();
    private QuizSO _quiz;

    private void Awake()
    {
        foreach (QuizSO quizSO in quizSOList.list)
            _quizList.Add(quizSO);

        Restart();
    }

    private void Update()
    {
        if (isStart)
        {
            _currentTime += Time.deltaTime;
            _timerText.text = $"{(_timeLimit - _currentTime).ToString("F2")}초";
            TimerCheck();
        }
    }

    private void Restart()
    {
        currentLevel = 0;
        score = 0;
        _scoreText.text = $"점수 : {score}";

        InitializeQuiz();
    }

    private void InitializeQuiz()
    {
        if (isComplete) return;

        _quiz = _quizList[currentLevel];
        _player.transform.position = new Vector3(0, 0, 0);
        _currentTime = 0;

        for (int i = 0; i < 4; i++)
        {
            _optionTexts[i].text = _quiz.optionText[i];
            _quizSprite[i].DOColor(Color.white, 0.5f);
        }
        _title.text = _quiz.titleText;
        isStart = true;
    }

    private void CheckAnswer()
    {
        if (_player._selected == _quiz.correctIndex)
        {
            score++;
            _scoreText.text = $"점수 : {score}";
        } 
        
        for (int i = 0; i < 4; i++)
        {
            if (i + 1 != _quiz.correctIndex)
                _quizSprite[i].DOColor(Color.red, 0.5f);
            else
                _quizSprite[i].DOColor(Color.green, 0.5f);
        }

        StartCoroutine(IntervalQuiz());
    }

    private void TimerCheck()
    {
        if (_currentTime >= _timeLimit)
        {
            isStart = false;
            _currentTime = 0;
            _timerText.text = $"{_currentTime}초";

            CheckAnswer();
        }
    }

    private void Complete()
    {
        _title.transform.parent.gameObject.SetActive(false);
        _quizSprite[0].transform.parent.gameObject.SetActive(false);

        if (score >= _quizList.Count - 2)
            OnComplete?.Invoke(true);
        else
            OnComplete?.Invoke(false);

        isComplete = true;
    }

    private IEnumerator IntervalQuiz()
    {
        yield return new WaitForSeconds(5f);
        currentLevel++;

        if (currentLevel >= _quizList.Count - 1)
            Complete();

        InitializeQuiz();
    }
}
