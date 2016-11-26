using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIQuickslotPanel : UIItemGrid {

    Backpack backpack;
   
    public void BindInventory(Backpack backpack) {
        // Creation Condition: The size of the inventory must be decided beforehand
        this.backpack = backpack;
        SetNumSlots(backpack.capacity);
      
    }
	
	public void Refresh() {
        for (int i = 0; i < backpack.capacity; ++i) {
            if (backpack.inventory[i] == null) {
                slotHandles[i].ClearSlot();
            } else {
                slotHandles[i].SetItem(backpack.inventory[i]);
            }
        }
    }

    public void ChangeColor (Color newColor) {
        foreach(UISlot slot in slotHandles) {
            slot.SetColor(newColor);
        }
    }
}
