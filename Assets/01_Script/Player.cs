using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerMovement
{

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
}
