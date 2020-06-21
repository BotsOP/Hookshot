using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionManager : MonoBehaviour
{
    public static AmmunitionManager instance;
    private int ammunitionCount = 10;
    [SerializeField] private Text ammunitionCountText;

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

    public bool ConsumeAmmo()
    {
        if(ammunitionCount > 0)
        {
            ammunitionCount--;
            UpdatedAmmoCountUi();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdatedAmmoCountUi()
    {
        ammunitionCountText.text = "Ammo: " + ammunitionCount;
    }
}
