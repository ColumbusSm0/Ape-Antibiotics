using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float hitPoints = 100f;
    public float CurrentHealth { get { return hitPoints; } }

    [SerializeField] float timeBeforeDestroy = 3f;
    Animator animator;
    public Image healthBar;
    public float timeBeforeReposition = 5f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        healthBar.fillAmount = hitPoints / 100;
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        //Debug.Log($"{this.name} health: {hitPoints}");

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        GetComponent<NavMeshAgent>().enabled = false;
        animator.SetTrigger("die");
        Destroy(gameObject, timeBeforeDestroy);
    }
}
