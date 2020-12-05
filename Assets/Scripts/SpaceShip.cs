﻿using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceShip : Destructible
{
    [Header("Space ship")]
    [SerializeField] private float thrustForce;
    [SerializeField] private float torqueForce;

    [SerializeField] private float maxLinearVelocity;
    [SerializeField] private float maxAngularVelocity;

    private Rigidbody thisRigidbody;
    
    public Vector3 ControlThrust { get; set; }
    public Vector3 ControlTorque { get; set; }

    private void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        UpdateRigidbody();
    }

    private void UpdateRigidbody()
    {
        ControlThrust = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            ControlThrust += Vector3.forward;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            ControlThrust -= Vector3.forward;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            ControlThrust += Vector3.right;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            ControlThrust -= Vector3.right;
        }
        
        thisRigidbody.AddRelativeForce(Time.fixedDeltaTime * thrustForce * ControlThrust, ForceMode.Force);
    }
}
