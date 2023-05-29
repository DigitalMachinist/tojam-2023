using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationHandler : MonoBehaviour
{

    public GameObject player; // Visuals
    public Animator animator;
    public Transform cam;
    private Rigidbody rb;
    private float speed;
    private Vector3 direction;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
         // Calculate the displacement since the last frame
        Vector3 displacement = transform.position - lastPosition;

        // Calculate the speed based on the magnitude of displacement and the time taken
        speed = displacement.magnitude / Time.deltaTime;

        // Update the last position
        lastPosition = transform.position;

        animator.SetFloat("Speed", speed);

        // speed = rb.velocity.magnitude;
        
        // animator.SetFloat("Speed", speed);

    }
}
