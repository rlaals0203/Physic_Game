using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _quiz;
    [SerializeField] private GameObject _quizSprites;

    private void Awake()
    {
        _menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnPlay()
    {
        Time.timeScale = 1.0f;
        _player.SetActive(true);
        _menu.SetActive(false);
        _quiz.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
