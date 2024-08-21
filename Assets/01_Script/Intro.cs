using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    [SerializeField] private Image _background;


    private void OnFadeOut()
    {
        _background.DOFade(0, 0.5f);
    }
}
