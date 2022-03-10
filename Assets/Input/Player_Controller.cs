using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movX;
    private float movY;
    private bool isGrounded = false;
    // public InputAction PlayerControls;


    [SerializeField] float speed = 10;
    [SerializeField] private float jumpForce = 10f;
    //private Vector2 startingPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //startingPosition = transform.position;
    }
    void OnMove(InputValue movementVal)
    {
        Vector2 mov = movementVal.Get<Vector2>();
        movX = mov.x;
        movY = mov.y;

    }
    // Update is called once per frame

    void OnJump()
    {
        Debug.Log("jump");
        if (isGrounded)
        {
            Debug.Log("jump 2");
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    void OnFall()
    {
        if (transform.position.y <= 0)
            return;
        if (isGrounded)
        {
            rb.GetComponent<Collider2D>().isTrigger = true;
        }
        Invoke("StopFall", .5f);

    }

    void StopFall()
    {
        Debug.Log("stop!");
        rb.GetComponent<Collider2D>().isTrigger = false;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movX * speed, rb.velocity.y);
    }
}
