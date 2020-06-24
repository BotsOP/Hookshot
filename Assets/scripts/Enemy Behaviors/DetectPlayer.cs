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
            inRange = true;
            hasTarget = true;
            SetState(new EnemyChase(this));
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("player exited my radius");
            inRange = false;
            SetState(new EnemyChase(this));
        }
    }
}
