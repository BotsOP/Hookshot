using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public GameObject gunPrefab;
    public GameObject bullet;

    [Header("Stats")]
    public int minimumDmg;
    public int maximumDmg;
    public float maximumRange;
}
