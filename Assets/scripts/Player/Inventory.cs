using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<GameObject, int> items = new Dictionary<GameObject, int>();

    public void addItem(GameObject item, int count)
    {
        if (items != null) {
            items.Add(item, count);
        }
    }

    public void removeItem(GameObject item)
    {
        // decrease item from inventory and remove item from list if its count is zero
        if (items != null && items.Count > 0 && items[item] > 0 && items[item]-- <= 0) {
            items.Remove(item);
        }
    }

    public bool contains(GameObject item) {
        return items != null && items.Count > 0 && items[item] > 0;
    }
}
