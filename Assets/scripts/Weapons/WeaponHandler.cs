using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public static WeaponHandler instance;

    public Gun currentGun;
    private Transform cameraTransform;
    private Transform FirePoint;
    private GameObject currentGunPrefab;
    public int currentGunDmg;
    private int gunDmg;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        CheckForShooting();
        
    }

    public void PickupGun(Gun gun)
    {
        if(currentGun != null)
        {
            Instantiate(currentGun.gunPickup, transform.position, Quaternion.identity);
            Destroy(currentGunPrefab);
        }
        currentGun = gun;
        currentGunPrefab = Instantiate(gun.gunPrefab, transform);
        gunDmg = gun.currentGunDmg;
        Debug.Log(gunDmg);
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentGun.OnMouseDown(cameraTransform);
        }
        else if (Input.GetMouseButton(0))
        {
            currentGun.OnMouseHold(cameraTransform);
        }
    }
}
