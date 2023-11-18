using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreoController : MonoBehaviour
{

    [Header("Oreo Properties")]
    [SerializeField] private float _bounceAmount;
    [SerializeField] private float _bounceSpeed;
    
    private float _randOffset;

    private void Start()
    {
        _randOffset = Random.Range(0, 360);
    }

    private void Update()
    {
        float heightOffset = Mathf.Sin(Time.time * _bounceSpeed + _randOffset) * _bounceAmount;
        transform.position = new Vector2(transform.position.x, transform.position.y + heightOffset);
    }
}
