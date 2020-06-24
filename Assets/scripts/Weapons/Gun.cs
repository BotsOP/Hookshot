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
    public AmmunitionTypes ammunitionType;
    public int minimumDmg;
    public int maximumDmg;
    public float maximumRange;
    public int currentGunDmg = 1;

    protected void Fire(Transform camera, Transform FirePoint)
    {
        if (AmmunitionManager.instance.ConsumeAmmo(ammunitionType))
        {
            RaycastHit whatIHit;
            if (Physics.Raycast(camera.position, camera.forward, out whatIHit, Mathf.Infinity))
            {
                //Debug.Log("I hit: " + whatIHit.collider.gameObject.name);
                Vector3 fireDirection = whatIHit.point - FirePoint.position;
                Instantiate(bullet, FirePoint.position, Quaternion.LookRotation(fireDirection, Vector3.up));
                float normalisedDistance = whatIHit.distance / maximumRange;
                if (normalisedDistance <= 1)
                {
                    currentGunDmg = Mathf.RoundToInt(Mathf.Lerp(maximumDmg, minimumDmg, normalisedDistance));
                }
            }
        }
    }

    public virtual void OnMouseDown(Transform camera, Transform FirePoint) { }

    public virtual void OnMouseHold(Transform camera, Transform FirePoint) { }
}
