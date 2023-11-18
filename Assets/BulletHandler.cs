using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [Header("Bullet Properties")]
    [SerializeField] private float _speed;

    private Vector2 _direction;

    private void Start()
    {
        Vector2 mouseScreenPos = Input.mousePosition;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        _direction = mouseWorldPos - new Vector2(transform.position.x, transform.position.y);
        _direction.Normalize();  // Ensure x and y magnitudes are always the same!
    }

    private void Update()
    {
        transform.Translate(_direction * _speed);
    }

}
