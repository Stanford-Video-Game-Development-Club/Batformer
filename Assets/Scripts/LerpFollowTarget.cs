using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFollowTarget : MonoBehaviour
{

    [Header("Target Assignment")]
    [SerializeField] private Transform _transformToFollow;
    [Tooltip("Distance away until camera stops trying to lerp towards target.")]
    [SerializeField] private float _maxFollowDistance;

    private void Awake()
    {
        Debug.Assert(_transformToFollow != null, "Transform for object to follow was not assigned!", this);
    }

    private void FixedUpdate()
    {
        // If this object is too far, make it lerp towards the target
        if (Vector2.Distance(transform.position, _transformToFollow.position) > _maxFollowDistance)
        {
            Vector3 newPos = Vector2.Lerp(transform.position, _transformToFollow.position, 0.1f);
            newPos.z = -10;
            transform.position = newPos;
        }
    }

}
