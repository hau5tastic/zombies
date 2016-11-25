using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIQuickslot : MonoBehaviour {

    Image[] quickslots;
	void Start () {
        quickslots = GetComponentsInChildren<Image>();
	}
	
	public void Refresh(Backpack backpack) {
        List<Item> inventory = backpack.inventory;
        // i = 0 is where the script is
        for (int i = 0; i < backpack.inventory.Count; ++i) {
            quickslots[i+1].sprite = inventory[i].sprite;
        }
    }
}
