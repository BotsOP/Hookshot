using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : Enemy
{

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
}
