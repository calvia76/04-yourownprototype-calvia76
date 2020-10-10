using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float speed = 3;

    private Rigidbody rb;

    public LayerMask groundlayer;

    public float jumpForce = 5;

    public SphereCollider col;
    private float movementX;
    private float movementY;
    float distance = 10;

    



    #region Monobehavior API
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        
        movementY = movementVector.y;
        transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        
    }
    
    void Update()
    {
        //transform.Rotate(Vector3.up * movementX * turnSpeed * Time.deltaTime);
        Vector3 movement = new Vector3(movementX, 0,movementY);
        
        rb.AddForce(movement * speed);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center,
            new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .95f, groundlayer);
    }
    #endregion
    

    
}
