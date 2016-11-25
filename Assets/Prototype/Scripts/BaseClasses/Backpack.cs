using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerController))]
public class Backpack : MonoBehaviour, IInventory {
    UIQuickslot uiQuickslot;

    PlayerController selfCharacter;
    public List<Item> inventory;
    // public int slots;
    private int numItems;
	
	void Start () {
        selfCharacter = GetComponent<PlayerController>();
        uiQuickslot = FindObjectOfType<UIQuickslot>();
        // inventory = new List<Item>();
        numItems = 0;
        Refresh();
    }
	
	public void AddItem(Item item) {
        item.OnPickup(selfCharacter);
        inventory.Add(item);
        numItems++;
    }

    public void DiscardItem(int index) {
        inventory.RemoveAt(index);
        numItems--;
    }

    public void UseItem(int index) {
        inventory[index].OnUse();
        Refresh();
        numItems--;
    }

    public void Refresh() {
        uiQuickslot.Refresh(this);
    }
}
