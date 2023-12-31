using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackSpeed;
    private AudioSource Au;
    private float nextAttackTime = 0f;
    private void Start()
    {
        Au = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (nextAttackTime <= Time.time)
        {
            if (Input.GetKeyDown(KeyCode.K))
                    {
                        Attack();
                        nextAttackTime = Time.time + 1 / attackSpeed;
                    }
        }
        
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        Au.Play();
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (var enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAI>().TakeDamage(20);
            Debug.Log("hit");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
