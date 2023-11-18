using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreoController : MonoBehaviour
{
    [SerializeField] private float bounceAmount;
    [SerializeField] private float bounceSpeed;
    private float randOffset;


    // Start is called before the first frame update
    void Start()
    {
        randOffset = Random.Range(0, 360);
    }

    // Update is called once per frame
    void Update()
    {
        float heightOffset = Mathf.Sin(Time.time * bounceSpeed + randOffset) * bounceAmount;
        transform.position = new Vector2(transform.position.x, transform.position.y + heightOffset);
    }
}
