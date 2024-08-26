using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/Quiz")]
public class QuizSO : ScriptableObject
{
    public int correctIndex;
    public string titleText;
    public string[] optionText;
}
