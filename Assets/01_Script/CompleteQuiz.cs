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
        _finalScoreText.text = $"���� ���� : {_quiz.score} / {_quiz._quizList.Count}";

        if (isSucess)
            _titleText.text = "�����մϴ�. �����ϼ̽��ϴ�.";
        else
            _titleText.text = "�ƽ��Ե�. �����ϼ̽��ϴ�.";
    }

    public void OnTitle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
