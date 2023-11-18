using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootHandler : MonoBehaviour
{

    [Header("Prefab Assignments")]
    public GameObject bulletPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

}
