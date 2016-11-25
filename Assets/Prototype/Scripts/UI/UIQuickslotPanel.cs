using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIQuickslotPanel : MonoBehaviour {

    public GameObject quickslotPrefab;
    public Sprite emptySprite;

    int numSlots;
    int slotDimensions = 50; // Slot size.. as in width x height
    Backpack backpack;
    UIQuickslot[] quickslots;
   
    public void BindInventory(Backpack backpack) {
        // Creation Condition: The size of the inventory must be decided beforehand
        this.backpack = backpack;
        numSlots = backpack.capacity;
        for (int i = 0; i < numSlots; ++i) {
            GameObject go = Instantiate(quickslotPrefab, transform) as GameObject;
            UIQuickslot tmp = go.GetComponent<UIQuickslot>();
            tmp.SetIndex(i + 1);
        }
        GetComponent<RectTransform>().sizeDelta = new Vector2(numSlots * slotDimensions, GetComponent<RectTransform>().sizeDelta.y);
        quickslots = GetComponentsInChildren<UIQuickslot>();

    }
	
	public void Refresh() {
        for (int i = 0; i < numSlots; ++i) {
            if (backpack.inventory[i] == null) {
                quickslots[i].SetSprite(emptySprite);
            } else {
                quickslots[i].SetSprite(backpack.inventory[i].GetSprite());
            }
        }
    }

    public void ChangeColor (Color newColor) {
        for (int i = 0; i < numSlots; ++i) {
            quickslots[i].ChangeColor(newColor);
        }
    }
}
