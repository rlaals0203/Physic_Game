using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : PlayerMovement
{
    [SerializeField] private SpriteRenderer[] _quizSprite;
    [SerializeField] private Quiz _quizCompo;
    public int _selected;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Quiz") && _quizCompo.isStart)
        {
            _selected = int.Parse
                (collision.name.ToString().Substring(collision.name.Length - 1, 1));

            _quizSprite[_selected - 1].DOColor(Color.cyan, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_quizCompo.isStart)
            _quizSprite[_selected - 1].DOColor(Color.white, 0.5f);
    }
}
