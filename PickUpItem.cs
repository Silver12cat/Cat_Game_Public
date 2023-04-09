using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = collision.GetComponent<Inventory>();
        if (inventory)
        {
            bool pickedUp = inventory.PickupItem(gameObject);
            if (pickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
