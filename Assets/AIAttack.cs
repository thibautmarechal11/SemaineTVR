using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    AIController AIController;
    Animator anim;

    public int damage;
    public float attackRate = 1;
    
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        AIController = GetComponent<AIController>();
    }

    private void OnEnable()
    {
        StartCoroutine(attackCooldown());
    }

    IEnumerator attackCooldown()
    {
        yield return new WaitForSeconds(attackRate);
        Attack();

        
    }

    public void Attack()
    {
        StartCoroutine(attackCooldown());
        anim.SetTrigger("attack");
    }

    void DealDamage()
    {
        PlayerHealth.Instance.TakeDamage(damage);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
