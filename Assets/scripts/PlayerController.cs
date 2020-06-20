using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float raycastDistance;
    public Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    public Vector3 standScale = new Vector3(1, 1, 1);

    public delegate void FoundTarget();
    public static PlayerController current;

    private Rigidbody rb;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
        Sprint();
        //Crouch();
    }

    public event Action onTargetTrigger;
    public void TargetFound()
    {
        if (onTargetTrigger != null)
            onTargetTrigger();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            Debug.Log("I hit an enemy detection range " + other.gameObject.name);
            PlayerController.current.TargetFound();
        }
    }

    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;

        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPos);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }

    private void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            speed = 5;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
        {
            speed = 3;
        }
    }

    //private void Crouch()
    //{
    //    Vector3 newScale;
        
        
    //    if (Input.GetKey(KeyCode.LeftControl))
    //    {
    //        speed = 1;
    //        newScale = crouchScale;
    //        transform.localScale = newScale;
    //    }
    //    if (Input.GetKeyUp(KeyCode.LeftControl))
    //    {
    //        speed = 3;
    //        newScale = standScale;
    //        transform.localScale = newScale;
    //    }
    //}

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.blue);
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance); ;
    }

    
}
