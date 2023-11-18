using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("Player Properties")]
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damageAmount;
    [SerializeField] private LayerMask _enemyLayer;

    private void Update()
    {
        // If E is pressed, find enemies in radius, and
        // call TakeDamage() function on all enemies.
        if (Input.GetKeyDown(KeyCode.E)) {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _attackRange, _enemyLayer);
            foreach (Collider2D enemy in enemies) {
                GameObject obj = enemy.gameObject;
                if (obj.TryGetComponent(out EnemyController enemyController))
                {
                    enemyController.Health -= _damageAmount;
                }
            }
        }
    }

}
