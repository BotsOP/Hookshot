using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyStats enemyStats;
    public Slider healthbarSlider;
    public Image healthbarFillImage;

    private int currentHealth;
    public int switchState = 0;
    public float gameTimer;
    public int seconds = 0;
    public Vector3 wanderPos;
    public bool hasTarget;
    public bool inRange;
    public float rotationSpeed = 5f;
    public float rayCastDis = 10f;

    public Color maxHealthColor;
    public Color minHealthColor;
    
    private State currentState;
    
    RaycastHit hit;
    
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject target;

    public NavMeshAgent agent;

    void Start()
    {
        PlayerController.current.onTargetTrigger += TargetFound;
        currentHealth = enemyStats.maxHealth;
        SetHealthbarUI();
        SetState(new EnemyWander(this));
        WanderAround();
        agent.speed = 2;
    }

    private void TargetFound()
    {
        Debug.Log("I received this event name: " + gameObject.name);
        target = GameObject.Find("Player");
        hasTarget = true;
        SetState(new EnemyChase(this));
    }

    void Update()
    {
        CheckIfEnemyInfront();

        if(inRange && target != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        }
    }

    public void SetState(State state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("found player");

            target = other.gameObject;
            hasTarget = true;
            SetState(new EnemyChase(this));
        }

    }

    public void CheckIfEnemyInfront()
    {
        for (int i = -150; i < 150; i += 10)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow, rayCastDis);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayCastDis))
            {
                if(hit.collider.gameObject.name == "Player" && !inRange)
                {
                    inRange = true;
                    SetState(new EnemyAttack(this));
                    Attack();
                }
                
            }
        }
    }

    public void fireBullet()
    {
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
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
        if (currentHealth <= 0)
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

    private void OnDestroy()
    {
        PlayerController.current.onTargetTrigger -= TargetFound;
    }
}
