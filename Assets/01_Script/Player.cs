using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerMovement
{
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
        if (collision.CompareTag(""))
        {
            _selected = int.Parse
                (collision.name.ToString().Substring(collision.name.Length, 1));
        }
    }
}
