using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerController))]
public class Backpack : MonoBehaviour, IInventory {

    UIQuickslotPanel uiQuickslotPanel;
    PlayerController selfCharacter;
    public Item[] inventory;
    public int capacity = 5;
    private int currentSize;
	
	void Start () {
        currentSize = 0;
        selfCharacter = GetComponent<PlayerController>();
        uiQuickslotPanel = FindObjectOfType<UIQuickslotPanel>();
        inventory = new Item[capacity];
        uiQuickslotPanel.BindInventory(this);
        Refresh();
    }
	
	public void AddItem(Item item) {
        if (IsFull()) return;
        item.OnPickup(selfCharacter);
        int emptySlot = FindEmptySlot();
        if (emptySlot != -1) 
            inventory[emptySlot] = item;
        ++currentSize;
        Refresh();
    }

    public void DiscardItem(int index) {
        --currentSize;
        inventory[index].OnDrop();
        inventory[index] = null;
        Refresh();
    }

    public void UseItem(int index) {

        // Note: Don't use discard item here instead of removing it manually; because 
        // discard could spawn an item somewhere if dropped;
        --currentSize;
        if (inventory[index] == null) return;
        inventory[index].OnUse();
        inventory[index] = null;
        Refresh();
    }

    private bool IsFull() {
        return currentSize >= capacity;
    }

    private int FindEmptySlot() {
        for (int i = 0; i < capacity; ++i) {
            if (inventory[i] == null) return i;
        }
        return -1;
    }

    public int GetCurrentSize() {
        return currentSize;
    }

    public void Refresh() {
        uiQuickslotPanel.Refresh();
    }
}
