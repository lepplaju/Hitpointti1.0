using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private Transform pukki;
    [SerializeField] private Rigidbody2D enemyRb;
    public float moveSpeed =1f;
    public float knockBackMultiplier;
    public bool canMove = true;
    [SerializeField] private PukkiHPController pukkiHPController;
    [SerializeField] private bool _pukkiOnElossa;
    private TimerScript timerScript;

    private void Start()
    {
        timerScript = GameObject.FindGameObjectWithTag("Background").GetComponent<TimerScript>();
        _pukkiOnElossa = timerScript.pukkiOnElossa;
        if (_pukkiOnElossa)
        {
            pukkiHPController = GameObject.FindGameObjectWithTag("HpCanvas").GetComponent<PukkiHPController>();
        }   
        //knockBackMultiplier = 50f;
        enemyRb = GetComponent<Rigidbody2D>();

        if (_pukkiOnElossa)
        {
            pukki = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        if(pukki && canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position,pukki.position, moveSpeed * Time.deltaTime);
        }   
    }

    public void knockBack(float force)
    {
        canMove = false;
        Invoke("MoveTrue", .05f);
        enemyRb.AddForce((transform.position-pukki.transform.position) *force);
        //Vector2.MoveTowards(pukki.position, transform.position,knockBackMultiplier * Time.deltaTime);
    }
    private void MoveTrue()
    {
        canMove = true;
    }
}
