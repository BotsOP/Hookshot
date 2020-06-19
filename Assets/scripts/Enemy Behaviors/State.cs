using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected readonly Enemy _system;
    
    public State(Enemy system)
    {
        _system = system;
    }
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Wander()
    {
        yield break;
    }

    public virtual IEnumerator Chase()
    {
        yield break;
    }

    public virtual IEnumerator Attack()
    {
        yield break;
    }
}