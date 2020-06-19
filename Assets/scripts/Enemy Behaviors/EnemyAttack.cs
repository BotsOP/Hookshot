using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : State
{
    public EnemyAttack(Enemy system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Im attacking rn");
        yield break;
    }

    public override IEnumerator Attack()
    {
        while (_system.inRange)
        {
            _system.agent.SetDestination(_system.transform.position);
            Quaternion targetRotation = Quaternion.LookRotation(_system.target.transform.position - _system.transform.position);
            _system.transform.rotation = Quaternion.Slerp(_system.transform.rotation, targetRotation, _system.rotationSpeed);
            Debug.Log("im going to shoot now");
            _system.fireBullet();

            yield return new WaitForSeconds(1f);
            _system.inRange = false;
            _system.SetState(new EnemyChase(_system));
        }
        
        yield break;
    }
}
