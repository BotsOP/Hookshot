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
        while (true)
        {
            Vector3 randomPos = new Vector3(Random.Range(-4, 5), 0, Random.Range(-4, 5));
            _system.agent.SetDestination(_system.transform.position + randomPos);
            yield return new WaitForSeconds(2f);
            //_system.SetState(new EnemyChase(_system));
            _system.Chase();
        }  
    }
}
