using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyStats enemyStats;
    public Slider healthbarSlider;
    public Image healthbarFillImage;

    private int currentHealth;

    public Color maxHealthColor;
    public Color minHealthColor;

    public int switchState = 0;
    public float gameTimer;
    public int seconds = 0;
    public Vector3 wanderPos;
    private State currentState;
    public GameObject target;
    public bool hasTarget;

    public NavMeshAgent agent;

    void Start()
    {
        currentHealth = enemyStats.maxHealth;
        SetHealthbarUI();
        SetState(new EnemyWander(this));
        WanderAround();
    }

    public void SetState(State state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }

    public void WanderAround()
    {
        StartCoroutine(currentState.Wander());
    }

    public void Chase()
    {
        StartCoroutine(currentState.Chase());
    }

    public void Attack()
    {
        StartCoroutine(currentState.Attack());
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
        SetHealthbarUI();
    }

    private void CheckIfDead()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void SetHealthbarUI()
    {
        float healthPercentage = CalculateHealthPercentage();
        healthbarSlider.value = healthPercentage;
        healthbarFillImage.color = Color.Lerp(minHealthColor, maxHealthColor, (healthPercentage / 100));
    }

    private float CalculateHealthPercentage()
    {
        return ((float)currentHealth / (float)enemyStats.maxHealth) * 100;
    }
}
