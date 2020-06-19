using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : State
{
    public EnemyWander(Enemy system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Im wandering rn");
        yield break;
    }

    public override IEnumerator Wander()
    {
        while (!_system.hasTarget)
        {
            Vector3 randomPos = new Vector3(Random.Range(-4, 5), 0, Random.Range(-4, 5));
            Vector3 playerPos = new Vector3(_system.transform.position.x, _system.transform.position.y, _system.transform.position.z);
            Vector3 newPos = playerPos + randomPos;
            //Quaternion targetRotation = Quaternion.LookRotation(newPos - _system.transform.position);
            //_system.transform.rotation = Quaternion.Slerp(_system.transform.rotation, targetRotation, _system.rotationSpeed * Time.deltaTime);
            _system.agent.SetDestination(newPos);
            yield return new WaitForSeconds(2f);
        }
    }
}

