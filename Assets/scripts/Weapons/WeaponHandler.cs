using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public List<Gun> guns = new List<Gun>();

    public Gun currentGun;
    public int currentGunIndex;
    private Transform cameraTransform;
    private Vector3 fireDirection;
    private Transform FirePoint;
    private GameObject currentGunPrefab;
    public int currentGunDmg;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
        FirePoint = GameObject.Find("Firepoint" + guns[0].name).GetComponent<Transform>();
        currentGunIndex = 0;
        currentGun = guns[currentGunIndex];
    }

    private void Update()
    {
        CheckForShooting();
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
            currentGunIndex = 0;
            currentGun = guns[currentGunIndex];
            FirePoint = GameObject.Find("Firepoint" + currentGun.name).GetComponent<Transform>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[1].gunPrefab, transform);
            currentGunIndex = 1;
            currentGun = guns[currentGunIndex];
            FirePoint = GameObject.Find("Firepoint" + currentGun.name).GetComponent<Transform>();
        }
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentGun.OnMouseDown(cameraTransform, FirePoint);
        }

        if (Input.GetMouseButton(0))
        {
            currentGun.OnMouseHold(cameraTransform, FirePoint);
        }
    }
}
