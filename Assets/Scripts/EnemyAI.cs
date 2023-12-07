using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHP = maxHP;
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        anim.SetTrigger("Hurt");
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;


    }
}
