using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOpen : Interaction
{
    public GameObject requiredObject;

    public override void interact(Collider2D collision)
    {
        if (requiredObject != null)
        {
            GameObject playerGameObject = collision.gameObject;
            Player player = playerGameObject.GetComponent<Player>();

            if (player != null)
            {
                Inventory inventory = player.getInventory();
                if (inventory != null && inventory.contains(requiredObject))
                {
                    // TODO: goto
                }
                else { 
                    // TODO: popup message error
                }
            }
        }
        else { 
            // TODO: goto
        }
    }
}