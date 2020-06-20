using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20;
    public WeaponHandler weaponHandler;
    private int gunDmg;
    // Start is called before the first frame update
    void Start()
    {
        weaponHandler = GameObject.Find("WeaponHandler").GetComponent<WeaponHandler>();
        gunDmg = weaponHandler.currentGun.maximumDmg;
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
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
        }
        if (other.gameObject.name != "Player" && other.GetType() != typeof(SphereCollider))
        {
            Destroy(gameObject);
        }
        
    }

}
