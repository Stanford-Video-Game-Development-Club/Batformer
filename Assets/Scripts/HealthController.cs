using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [Header("Health Properties")]
    [SerializeField] private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

}
