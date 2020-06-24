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
        Debug.Log("trying to pickup " + gun.gunName);
    }
    public void OnEndLook()
    {
        Debug.Log("Stopped looking at " + gun.gunName);
    }
}
