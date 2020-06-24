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
        yield break;
    }

    

    public override IEnumerator Attack()
    {
        if (_system.inRange && (Time.time - _system.lastTimeFired > 1 / _system.fireRate))
        {
            _system.lastTimeFired = Time.time;
            Time.timeScale = 1f;
            _system.cantShoot = true;
            _system.agent.SetDestination(_system.transform.position);
            _system.fireBullet();
        }
        _system.agent.SetDestination(_system.transform.position);
        yield return new WaitForSecondsRealtime(1);
        if(!_system.inRange)
            _system.SetState(new EnemyChase(_system));

        yield break;
    }

    
}
