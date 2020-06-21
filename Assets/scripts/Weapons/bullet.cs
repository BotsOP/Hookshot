using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20;
    public WeaponHandler weaponHandler;

    public Gun currentGun;
    private int gunDmg;

    void Start()
    {
        weaponHandler = GameObject.Find("WeaponHandler").GetComponent<WeaponHandler>();
        currentGun = weaponHandler.guns[weaponHandler.currentGunIndex];
        gunDmg = currentGun.currentGunDmg;
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damageable = other.gameObject.GetComponent<IDamagable>();
        if (other.CompareTag("Enemy") && other.GetType() == typeof(CapsuleCollider))
        {
            damageable.DealDamage(gunDmg);
            Destroy(gameObject);
        }
        if (other.gameObject.name != "Player" && other.GetType() != typeof(SphereCollider))
        {
            Destroy(gameObject);
        }
        
    }

}
