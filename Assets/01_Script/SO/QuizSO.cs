using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/Quiz")]
public class QuizSO : ScriptableObject
{
    public string[] selection;
    public string quizDesc;
    public string answerExplanation;
    public int correctNumber;
}
