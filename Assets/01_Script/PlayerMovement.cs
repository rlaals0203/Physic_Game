using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RigidCompo { get; private set; }
    public float moveSpeed;
    public float dashPower;

    private float x, y = 0;

    private void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        GetInput();
        RigidCompo.velocity = new Vector2(x, y) * moveSpeed;
    }

    public void Dash()
    {
        Vector2 dashDir = new Vector2(x, y);
        RigidCompo.AddForce(dashDir * dashPower, ForceMode2D.Impulse);
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }
}
