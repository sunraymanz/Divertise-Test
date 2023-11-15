using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<int> itemIDList;
    public InventorySlot[] inventoryUI;
    int index = 0;

    public void Additem(GameObject newItem)
    {
        //check if can pick up more the item
        if (index < 16)
        {
            itemIDList[index] = newItem.GetComponent<Item>().id;
            inventoryUI[index].AddItem(newItem.GetComponent<Item>());
            index++;
            Destroy(newItem);
        }
        else { FindObjectOfType<WarningText>().ShowWarning("Inventory Is Full"); }
    }
}
