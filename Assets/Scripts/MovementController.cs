using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Vector2 movementInput;
    private float moveSpeed = 4f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform keskiPiste;
    [SerializeField] private PukkiHPController pukkiHPController;

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.velocity = movementInput * moveSpeed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Border") {
            Vector3 repelDir = (keskiPiste.position - transform.position).normalized;
            transform.position = transform.position + repelDir*.3f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            pukkiHPController.PlayHitSound();
            pukkiHPController.TakeDamage(9f);
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            pukkiHPController.TakeDamage(1);
        }
    }

}
