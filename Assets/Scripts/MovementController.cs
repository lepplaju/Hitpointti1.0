using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private Vector2 movementInput;
    private float moveSpeed = 4f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform keskiPiste;


    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.velocity = movementInput * moveSpeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.tag);        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Border") {
            Vector3 repelDir = (keskiPiste.position - transform.position).normalized;
            transform.position = transform.position + repelDir*.3f;
        }
    }
}
