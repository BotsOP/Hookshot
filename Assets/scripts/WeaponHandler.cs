using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public List<Gun> guns = new List<Gun>();

    public Gun currentGun;
    private Transform cameraTransform;
    private Vector3 fireDirection;
    private Transform FirePoint;
    private GameObject currentGunPrefab;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
        FirePoint = GameObject.Find("Firepoint" + guns[0].name).GetComponent<Transform>();
        currentGun = guns[0];
    }

    private void Update()
    {
        CheckForShooting();
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
            currentGun = guns[0];
            FirePoint = GameObject.Find("Firepoint" + currentGun.name).GetComponent<Transform>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[1].gunPrefab, transform);
            currentGun = guns[1];
            FirePoint = GameObject.Find("Firepoint" + currentGun.name).GetComponent<Transform>();
        }
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit whatIHit;
            if (Physics.Raycast(cameraTransform.position, transform.forward, out whatIHit, Mathf.Infinity))
            {
                Debug.Log("I hit: " + whatIHit.collider.gameObject.name);
                FirePoint = GameObject.Find("Firepoint" + currentGun.name).GetComponent<Transform>();
                Debug.DrawRay(cameraTransform.position, transform.forward, Color.green, 20);
                fireDirection = whatIHit.point - FirePoint.position;
                Instantiate(currentGun.bullet, FirePoint.position, Quaternion.LookRotation(fireDirection, Vector3.up));
            }
        }
    }
}
