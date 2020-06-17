using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyStats enemyStats;
    private int currentHealth;

    void Start()
    {
        currentHealth = enemyStats.maxHealth;
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
