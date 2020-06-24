using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPickup : MonoBehaviour, ILootable
{
    public int ammunitionCount;
    public AmmunitionTypes ammunitionTypes;

    public void OnStartLook()
    {
        Debug.Log("Started looking at " + ammunitionTypes);
    }
    public void OnInteract()
    {
        AmmunitionManager.instance.AddAmmunition(ammunitionCount, ammunitionTypes);
        Destroy(gameObject);
    }
    public void OnEndLook()
    {
        Debug.Log("Stopped looking at " + ammunitionTypes);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.GetComponent<PlayerController>() != null)
    //    {
    //        AmmunitionManager.instance.AddAmmunition(ammunitionCount, ammunitionTypes);
    //        Destroy(gameObject);
    //    }
    //}
}
