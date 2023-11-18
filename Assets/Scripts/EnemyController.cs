using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Enemy Properties")]
    [SerializeField] private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

}
