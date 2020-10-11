using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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

    public GameObject coin;

    private int count = 0;
    public TextMeshProUGUI CountText;
    public GameObject winTextObject;


    #region Monobehavior API
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        
        SetCountText();
        winTextObject.SetActive(false);
    }
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        
        movementY = movementVector.y;
        transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        
    }
    
    void FixedUpdate()
    {
        
        
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
    public void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.tag=="End_Level")
        {
            winTextObject.SetActive(true);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

}
