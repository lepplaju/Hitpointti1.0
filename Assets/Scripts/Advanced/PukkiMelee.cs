using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukkiMelee : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayer;
    [SerializeField] private Animator pukkiAnimator;

    public int attackDamage = 30;

    private void Awake()
    {
        pukkiAnimator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playAttack();
            Invoke("Attack", .2f);
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

    private void playAttack()
    {
        pukkiAnimator.SetTrigger("MeleeAttack");
    }
}