using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    
    public LayerMask enemyLayer;

    private AudioSource audioSource;
    public AudioClip swing;

    public int attackDamage = 30;
    public float attackRange = 1f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySwingSound()
    {
        audioSource.clip = swing;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
                    {
                        Debug.Log("ly�tyon");
                        Attack();
                        PlaySwingSound();
                        nextAttackTime = Time.time + 1f / attackRate;
                    }
        }
        
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHPController>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {

        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}