using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : State
{
    public EnemyChase(Enemy system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Im chasing rn");
        _system.Chase();
        yield break;
    }

    public override IEnumerator Chase()
    {
        while (_system.hasTarget && !_system.inRange)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_system.target.transform.position - _system.transform.position);
            _system.transform.rotation = Quaternion.Slerp(_system.transform.rotation, targetRotation, _system.rotationSpeed);
            //Vector3 lookAtTarget = new Vector3(0, _system.target.transform.position.y, 0);
            //_system.transform.LookAt(lookAtTarget);
            _system.agent.SetDestination(_system.target.transform.position);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
}
