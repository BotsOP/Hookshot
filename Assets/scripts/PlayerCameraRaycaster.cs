using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRaycaster : MonoBehaviour
{
    [SerializeField] private float raycastDistance;
    private ILootable currentLook;

    private void Update()
    {
        HandleRaycast();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentLook != null)
            {
                currentLook.OnInteract();
            }
        }
    }

    private void HandleRaycast()
    {
        RaycastHit whatIHit;
        if(Physics.Raycast(transform.position, transform.forward, out whatIHit, raycastDistance))
        {
            ILootable lootable = whatIHit.collider.GetComponent<ILootable>();
            if(lootable != null)
            {
                if (lootable == currentLook)
                    return;
                else if (currentLook != null)
                {
                    currentLook.OnEndLook();
                    currentLook = lootable;
                    currentLook.OnStartLook();
                }
                else
                {
                    currentLook = lootable;
                    currentLook.OnStartLook();
                }
            }
            else
            {
                if(currentLook != null)
                {
                    currentLook.OnEndLook();
                    currentLook = null;
                }
            }
        }
        else
        {
            if(currentLook != null)
            {
                currentLook.OnEndLook();
                currentLook = null;
            }
        }
    }
}
