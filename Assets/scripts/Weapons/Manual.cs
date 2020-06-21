using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Manual Gun", menuName = "Guns/Manual")]
public class Manual : Gun
{
    public float fireRate;
    private float lastTimeFired;
    public bool canFire;

    public void OnEnable()
    {
        lastTimeFired = 0;
    }

    public override void OnMouseDown(Transform camera, Transform FirePoint)
    {
        Debug.Log(Time.time + "                " + lastTimeFired);
        if (Time.time - lastTimeFired > 1 / fireRate)
        {
            lastTimeFired = Time.time;
            canFire = true;
        }
        if (canFire)
        {
            Fire(camera, FirePoint);
            canFire = false;
        }
        
    }
}
