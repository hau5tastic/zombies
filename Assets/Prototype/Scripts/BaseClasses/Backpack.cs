using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerController))]
public class Backpack : MonoBehaviour, IInventory {

    PlayerController selfCharacter;
    List<Item> inventory;
    public int slots;
    private int numItems;
	
	void Start () {
        selfCharacter = GetComponent<PlayerController>();
        inventory = new List<Item>();
        numItems = 0;
	}
	
	public void AddItem(Item item) {
        item.OnPickup(selfCharacter);
        inventory.Add(item);
    }

    public void DiscardItem(int index) {
        inventory.RemoveAt(index);
    }

    public void UseItem(int index) {
        inventory[index].OnUse();
        Refresh();
    }

    private void Refresh() {
        // For UI stuff
    }
}
