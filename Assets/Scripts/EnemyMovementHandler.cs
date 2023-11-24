using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LookDirection
{
    LEFT = 0, RIGHT
}

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovementHandler : MonoBehaviour
{

    [Header("Enemy Properties")]
    [Tooltip("The initial direction this enemy will be facing")]
    [SerializeField] private LookDirection _currDirection;
    [SerializeField] private float _enemyMoveSpeed;
    [Tooltip("Distance of the raycast shot out before enemy notices wall")]
    [SerializeField] private float _raycastDistance;
    [Header("Layer Assignments")]
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb2D;
    private Vector2 _currDirectionVector => new(_currDirection == LookDirection.LEFT ? -1 : 1, 0);

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(_enemyMoveSpeed * _currDirectionVector.x, _rb2D.velocity.y);
        // If enemy is hitting a wall after moving...
        if (IsHittingWall())
        {
            // Reverse current direction!
            _currDirection = (_currDirection == LookDirection.LEFT) ? 
                             LookDirection.RIGHT : LookDirection.LEFT;
        }
    }

    /// <summary>
    /// Shoots a raycast at the enemy's facing direction to check for wall collisions.
    /// </summary>
    /// <returns>True if the enemy is touching a wall, else False.</returns>
    private bool IsHittingWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _currDirectionVector, _raycastDistance, _groundLayer);
        return hit.collider != null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Draws the enemy's raycast distance (editor only for debugging!).
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawLine(transform.position, (Vector2)(transform.position) + _currDirectionVector * _raycastDistance);
    }
# endif

}
