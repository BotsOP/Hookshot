using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, ILootable
{
    [SerializeField] private Gun gun;

    public void OnStartLook()
    {
        Debug.Log("Started looking at " + gun.gunName);
    }
    public void OnInteract()
    {
        WeaponHandler.instance.PickupGun(gun);
        Destroy(gameObject);
    }
    public void OnEndLook()
    {
        Debug.Log("Stopped looking at " + gun.gunName);
    }
}
