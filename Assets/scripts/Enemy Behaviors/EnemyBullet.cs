using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20;
    public int damage = 10;
    void Start()
    {
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
        if (!other.CompareTag("Enemy") || other.GetType() != typeof(SphereCollider))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Player" && other.GetType() == typeof(CapsuleCollider))
        {
            //damageable.DealDamage(damage);
            Destroy(gameObject);
        }

    }

}
