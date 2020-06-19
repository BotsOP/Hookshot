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
        //Debug.Log("Im chasing rn");
        yield break;
    }

    public override IEnumerator Chase()
    {
        Debug.Log("hello!");
        yield break;
    }
}
