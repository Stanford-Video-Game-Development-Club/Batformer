using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPickupHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we collide with an oreo, destroy it and
        // increment our points (if it exists)!
        if (collision.gameObject.tag == "Oreo")
        {
            if (UIManager.Instance) UIManager.Instance.Points++;
            Destroy(collision.gameObject);
        }
    }

}
