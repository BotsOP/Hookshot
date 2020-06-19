using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
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
            damageable.DealDamage(10);
        }
        if (other.gameObject.name != "Player" && other.GetType() != typeof(SphereCollider))
        {
            Destroy(gameObject);
        }
        
    }

}
