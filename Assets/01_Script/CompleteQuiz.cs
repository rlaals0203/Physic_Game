using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteQuiz : MonoBehaviour
{
    [SerializeField] private GameObject _finalScreen;
    [SerializeField] private TextMeshProUGUI _titleText; 
    [SerializeField] private TextMeshProUGUI _finalScoreText; 
    private Quiz _quiz;

    private void Awake()
    {
        _quiz = GetComponent<Quiz>();
        _quiz.OnComplete.AddListener(OnCompleteQuiz);
    }

    public void OnCompleteQuiz(bool isSucess)
    {
        _finalScreen.SetActive(true);
        _finalScoreText.text = $"맞은 갯수 : {_quiz.score} / {_quiz._quizList.Count}";

        if (isSucess)
            _titleText.text = "축하합니다. 성공하셨습니다.";
        else
            _titleText.text = "아쉽게도. 실패하셨습니다.";
    }

    public void OnTitle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
