using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementHandler : MonoBehaviour
{

    [Header("Player Properties")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [Header("Layer Assignments")]
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb2D;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Control horizontal movement (setting velocity)
        RenderHorizontalMovement();
        // Control vertical movement (adding upwards force)
        RenderVerticalMovement();
        // Reverse gravity (invert gravity scale)
        RenderGravityMovement();
    }

    /// <summary>
    /// Moves the player left-right when keys on the horizontal axes are pressed.
    /// </summary>
    private void RenderHorizontalMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        if (hor != 0)
        {
            _rb2D.velocity = new Vector2(hor * _moveSpeed, _rb2D.velocity.y);
        }
    }

    /// <summary>
    /// Makes the player jump when the jump key is pressed AND the player is grounded.
    /// </summary>
    private void RenderVerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb2D.AddForce(new Vector2(_rb2D.velocity.x, _jumpPower),
                           ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Makes the player switch gravity when the gravity key is pressed AND the player
    /// is grounded..
    /// </summary>
    private void RenderGravityMovement()
    {
        if (Input.GetKeyDown(KeyCode.G) && IsGrounded())
        {
            _rb2D.gravityScale *= -1;
        }
    }

    /// <summary>
    /// Shoots a raycast at the player's feet to check if they are "grounded".
    /// <para>
    /// The definition of "grounded" differs depending on player gravity.
    /// Positive gravity means "grounded" is a downwards raycast, else "grounded"
    /// is an upwards raycast.
    /// </para>
    /// </summary>
    /// <returns>A bool that is True if the player is grounded, else False</returns>
    private bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = (_rb2D.gravityScale > 0) ? Vector2.down : Vector2.up;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, _groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

}