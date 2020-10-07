using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;

    private Rigidbody rb;

    public LayerMask groundlayer;

    public float jumpForce = 3;

    public SphereCollider col;
    private float movementX;
    private float movementY;
    public float turnSpeed = 20f;

    #region Monobehavior API
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        
        movementY = movementVector.y;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //transform.Rotate(Vector3.up * movementX * turnSpeed * Time.deltaTime);
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center,
            new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundlayer);
    }
    #endregion
}
