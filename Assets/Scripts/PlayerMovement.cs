using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpPower = 5;

    [SerializeField] private LayerMask ground;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D coll;

    private enum MovementState {idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        //Grab references from gameObject
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // Moving left - right
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when moving left - right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }

        UpdateAnimationParameters(horizontalInput);
    }

    private void UpdateAnimationParameters(float horizontalInput)
    {
        MovementState state;

        if (horizontalInput != 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if(body.velocity.y > 0.01f)
        {
            state = MovementState.jumping;
        }
        else if (body.velocity.y < -0.01f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }
}
