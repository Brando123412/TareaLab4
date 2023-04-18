using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy1 : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    
    public LayerMask layerMask;
    [SerializeField] float distanceModifier;
    [SerializeField] float velocity;
    Vector3 rayTransform;
    public event Action<Enemy1> Ongolpe; 
    public int golpeValue;
    void Start()
    {
        rayTransform =pointB.position;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,rayTransform,out hit, distanceModifier,layerMask))
        {
            velocity=0.5f;
            
        }else{
            velocity=0.1f;
            float t = Mathf.PingPong(Time.time*velocity, 1); 
            transform.position = Vector3.Lerp(pointA.position, pointB.position, t); 
        }
        Debug.DrawLine(transform.position,rayTransform,Color.blue);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PuntoA"))
        {
            rayTransform = pointB.position;
        }else if(other.gameObject.CompareTag("PuntoB"))
        {
            rayTransform = pointA.position;
        }
    }
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            Ongolpe?.Invoke(this);
        }
    }
}
