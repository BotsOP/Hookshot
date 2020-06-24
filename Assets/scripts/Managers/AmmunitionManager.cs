using System.CodeDom;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionManager : MonoBehaviour
{
    public static AmmunitionManager instance;
    [SerializeField] private Dictionary<AmmunitionTypes, int> ammunitionCounts = new Dictionary<AmmunitionTypes, int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        for (int i = 0; i < Enum.GetNames(typeof(AmmunitionTypes)).Length; i++)
        {
            ammunitionCounts.Add((AmmunitionTypes)i, 0);
        }
    }

    public void AddAmmunition(int value, AmmunitionTypes ammunitionType)
    {
        ammunitionCounts[ammunitionType] += value;
    }

    public bool ConsumeAmmo(AmmunitionTypes ammunitionType)
    {
        if(ammunitionCounts[ammunitionType] > 0)
        {
            ammunitionCounts[ammunitionType]--;
            return true;
        }
        else
        {
            return false;
        }
    }
}
