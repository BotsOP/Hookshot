using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy stats", menuName = "Enemy/Stats")]
public class EnemyStats : ScriptableObject
{
    public int maxHealth;
    public string enemyName;
}
