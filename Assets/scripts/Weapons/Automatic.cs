using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Automatic Gun", menuName = "Guns/Automatic")]
public class Automatic : Gun
{
    public float fireRate;
    private float lastTimeFired = 0;

    public void OnEnable()
    {
        lastTimeFired = 0;
    }

    public override void OnMouseHold(Transform camera)
    {
        if (Time.time - lastTimeFired > 1 / fireRate)
        {
            lastTimeFired = Time.time;
            Fire(camera);
        }
        
    }
}
