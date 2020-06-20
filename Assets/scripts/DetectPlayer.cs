using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Enemy enemy;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test!!!!!!!!!!!!!!!!!!");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("found player");

            enemy.target = other.gameObject;
            enemy.hasTarget = true;
            enemy.SetState(new EnemyChase(enemy));
        }

    }
}
