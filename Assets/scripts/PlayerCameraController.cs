using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float lookSensitivity;
    public float smoothing;

    private GameObject Player;
    public GameObject bullet;
    public GameObject firepoint;
    public Vector2 smoothedVelocity;
    public Vector2 currentLookingPos;
    public Vector2 inputValues;
    private Vector3 fireDirection;

    void Start()
    {
        Player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        inputValues = Vector2.Scale(inputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f / smoothing);

        currentLookingPos += smoothedVelocity;

        transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, Player.transform.up);
    }

    //private void CheckForShooting()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit whatIHit;
    //        if (Physics.Raycast(transform.position, transform.forward, out whatIHit, Mathf.Infinity))
    //        {
    //            IDamagable damageable = whatIHit.collider.GetComponent<IDamagable>();
    //            if (damageable != null)
    //            {
    //                damageable.DealDamage(10);
    //            }
    //        }
    //    }
    //}

    //private void CheckForShooting()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit whatIHit;
    //        if (Physics.Raycast(transform.position, transform.forward, out whatIHit, Mathf.Infinity))
    //        {
    //            Debug.DrawRay(transform.position, transform.forward, Color.green, 20);
    //            fireDirection = whatIHit.point - firepoint.transform.position;
    //            Instantiate(bullet, firepoint.transform.position, Quaternion.LookRotation(fireDirection, Vector3.up));
    //        }
    //    }
    //}
}
