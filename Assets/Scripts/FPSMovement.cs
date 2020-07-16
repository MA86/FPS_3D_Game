using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *** ATTRIBUTES ***
[RequireComponent(typeof(CharacterController))]

public class FPSMovement : MonoBehaviour
{
    // Publics
    public float Speed = 7;
    public float Gravity = -9.8f;

    // Privates
    private Transform _transform;
    private CharacterController controller;
    

    void Start()
    {
        // Get a reference to Transform
        this._transform = this.GetComponent<Transform>();
        this.controller = this.GetComponent<CharacterController>();
    }


    void Update()
    {
        // Get local direction of movement from keyboard input
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        
        // Prepare a vector based on the direction above
        Vector3 vector = new Vector3(horizontalDirection, 0f, verticalDirection);

        // Normalize the vector so that a diagonal vector is the same length
        vector = Vector3.Normalize(vector);
        
        // Scale the vector by speed, accounting for PC frame rate
        vector = vector * (this.Speed * Time.deltaTime);

        // Add gravity in the negative Y-axis
        vector.y = this.Gravity;

        // Transform vector's local direction to world direction
        vector = this._transform.TransformDirection(vector);
        
        // Move the object
        this.controller.Move(vector);
    }
}
