using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPickupItem : Interaction
{
    public GameObject[] items;

    public override void interact(Collider2D collision)
    {
        if (items != null)
        {
            GameObject playerGameObject = collision.gameObject;
            Player player = playerGameObject.GetComponent<Player>();

            if (player != null)
            {
                Inventory inventory = player.getInventory();
                if (inventory != null)
                {
                    for (int i = 0; i < items.Length; i++) {
                        inventory.addItem(items[i], 1);
                        player.setInventory(inventory);
                    }
                    
                    items = null;
                }
            }
        }
    }
}
