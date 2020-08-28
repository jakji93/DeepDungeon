using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    public Rigidbody2D rigidbody2D;
    public Animator animator;

    private Vector2 movement;
    private Vector2 lastMovement = new Vector2(1f, 0f);

    internal static class MoveStates
    {
        internal const string Horizontal = "Horizontal";
        internal const string Vertical = "Vertical";
        internal const string Speed = "Speed";
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        StoreLastMovement();
        Animate();
        FlipPlayer();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(movement.x, movement.y) * moveSpeed;
    }

    private void ProcessInput()
    {
        movement.x = Input.GetAxisRaw(MoveStates.Horizontal);
        movement.y = Input.GetAxisRaw(MoveStates.Vertical);
    }

    private void StoreLastMovement()
    {
        if (Mathf.Abs(movement.x) > Mathf.Epsilon || Mathf.Abs(movement.y) > Mathf.Epsilon)
        {
            lastMovement.x = movement.x;
            lastMovement.y = movement.y;
        }
    }

    private void Animate()
    {
        animator.SetFloat(MoveStates.Horizontal, lastMovement.x);
        animator.SetFloat(MoveStates.Vertical, lastMovement.y);
        animator.SetFloat(MoveStates.Speed, movement.sqrMagnitude);
    }

    private void FlipPlayer()
    {
        var playerHasHorizontalSpeed = Mathf.Abs(lastMovement.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed) transform.localScale = new Vector2(lastMovement.x, 1);
    }
}
