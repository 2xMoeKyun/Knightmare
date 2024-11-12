using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private bool isFacingRight = true;

    public static bool isAbleMove = true;


    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        //float moveX = Input.GetKey(KeyCode.D) ? 1.0f : (Input.GetKey(KeyCode.A) ? -1.0f : 0f);
        moveInput = new Vector2(moveX, 0f).normalized;
        if (!PlayerController.isAbleMove)
            moveInput = Vector2.zero;
    }


    private void FixedUpdate()
    {
        rb.linearVelocityX = moveInput.x * moveSpeed;
        animator.SetBool("Move", Convert.ToBoolean(moveInput.x));
        CheckTurn();

    }


    private bool CheckTurn()
    {
        bool check = moveInput.x > 0f ? isFacingRight : !isFacingRight;
        bool stand = moveInput.x == 0f ? isFacingRight : true;
        Turn(face: (check && stand));
        return check && stand;
    }

    private void Turn(bool face=true)
    {
        if (isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if(face)
            isFacingRight = !isFacingRight;
    }
}