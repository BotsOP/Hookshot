﻿using System.Collections;
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
    public Vector3 fireDirection;
    public bool hasTarget;
    public bool inRange;
    public float rotationSpeed = 5f;
    public float rayCastDis = 10f;
    public bool cantShoot = true;
    public int fireRate = 1;
    public float lastTimeFired;

    public Color maxHealthColor;
    public Color minHealthColor;
    
    private State currentState;
    public bool isEnemyChasing;
    
    RaycastHit hit;
    
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject target;
    public GameObject damageTextPrefab;

    public NavMeshAgent agent;

    public static float test2 = 0.5f;

    void Start()
    {
        PlayerController.current.onTargetTrigger += TargetFound;
        currentHealth = enemyStats.maxHealth;
        SetHealthbarUI();
        lastTimeFired = 0;
        agent.speed = 2;

        SetState(new EnemyWander(this));
        WanderAround();

        Debug.Log("this is the result " + Equals(new EnemyWander(this)));
    }

    private void TargetFound()
    {
        PlayerController.current.onTargetTrigger -= TargetFound;
        Debug.Log("I found the target: " + gameObject.name);
        target = GameObject.Find("Player");
        hasTarget = true;
        SetState(new EnemyChase(this));
    }

    void Update()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(test), Color.green, 20);
        CheckIfEnemyInfront();
        turnToTarget();
    }

    public void SetState(State state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }    

    public void fireBullet()
    {
        if (target == null)
            return;
        fireDirection = target.transform.position - firePoint.transform.position;
        Instantiate(bullet, firePoint.transform.position, Quaternion.LookRotation(fireDirection, Vector3.up));
    }

    public void turnToTarget()
    {
        if (inRange && target != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        }
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
        Instantiate(damageTextPrefab, transform.position, Quaternion.identity, transform).GetComponent<DamageText>().Initialise(damage);
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

    public Vector3 rayInFront;
    public void CheckIfEnemyInfront()
    {
        for (float i = -0.5f; i < 1; i += 0.5f)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(rayInFront), Color.yellow, rayCastDis);
            if (Physics.Raycast(transform.position, transform.TransformDirection(rayInFront), out hit, rayCastDis))
            {
                if (hit.collider.gameObject.name == "Player" && inRange)
                {
                    SetState(new EnemyAttack(this));
                    Attack();
                }
            }
            rayInFront = new Vector3(0, i, 1);
        }
    }

    private void OnDestroy()
    {
        PlayerController.current.onTargetTrigger -= TargetFound;
    }

    
}

