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
         
    }
    void Update()
    {
        CamTrigger camTrigger = gameObject.AddComponent<CamTrigger>();
        if (camTrigger.IsCollided.Equals("Right"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.World);

                //W:     rb.velocity = transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed, Space.World);

                //S:    rb.velocity = -transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = -transform.forward * speed;

                //D:    transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = transform.forward * speed; //W

                //A:    transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed, Space.World);
            }


        }else if (camTrigger.IsCollided.Equals("Left"))
        {

        }
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
