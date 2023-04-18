using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllr : MonoBehaviour
{
    [SerializeField] float velocity;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*velocity,rb.velocity.y, Input.GetAxis("Vertical")*velocity);
    }
}
