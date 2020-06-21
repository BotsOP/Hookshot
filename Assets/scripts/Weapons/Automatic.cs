using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Automatic Gun", menuName = "Guns/Automatic")]
public class Automatic : Gun
{

    public float fireRate;
    private float lastTimeFired;

    public override void OnMouseHold(Transform camera, Transform FirePoint)
    {
        if(Time.time - lastTimeFired > 1 / fireRate)
        {
            lastTimeFired = Time.time;
            RaycastHit whatIHit;
            if (Physics.Raycast(camera.position, camera.forward, out whatIHit, Mathf.Infinity))
            {
                Debug.Log("I hit: " + whatIHit.collider.gameObject.name);
                FirePoint = GameObject.Find("Firepoint" + name).GetComponent<Transform>();
                //Debug.DrawRay(cameraTransform.position, transform.forward, Color.green, 20);
                Vector3 fireDirection = whatIHit.point - FirePoint.position;
                Instantiate(bullet, FirePoint.position, Quaternion.LookRotation(fireDirection, Vector3.up));
                float normalisedDistance = whatIHit.distance / maximumRange;
                if (normalisedDistance <= 1)
                {
                    Debug.Log("Calculated dmg");
                    currentGunDmg = Mathf.RoundToInt(Mathf.Lerp(maximumDmg, minimumDmg, normalisedDistance));
                }
            }
        }
        
    }
}
