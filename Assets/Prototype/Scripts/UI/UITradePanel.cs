using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UITradePanel : MonoBehaviour {

    PlayerController[] playerControllers;
    UITradeslotPanel[] itemGrids;
    Button[] buttons;

    private List<Item> tradingItems;

	void Awake() {
        playerControllers = new PlayerController[2];
        itemGrids = new UITradeslotPanel[2];
        buttons = new Button[2];
        itemGrids = GetComponentsInChildren<UITradeslotPanel>();
        buttons = GetComponentsInChildren<Button>();
        tradingItems = new List<Item>();
    }

    public void BindPlayer(PlayerController player) {
        playerControllers[0] = player;
    }

    public void BeginTrade(PlayerController otherPlayer) {
        playerControllers[1] = otherPlayer;
    }

    private bool IsAlreadyBeingTraded(Item item) {
        foreach (Item myItem in tradingItems) {
            if (myItem == item) return true;
        }
        return false;
    }
	
    public void AddItem(Item item) {
        if (item == null) return;
        if (IsAlreadyBeingTraded(item)) return;
        // Networking: if player is this player,
        tradingItems.Add(item);
        itemGrids[0].AddItem(item);
    }

    public PlayerController GetOtherPlayer() {
        return playerControllers[1];
    }

    public void Refresh() {
        tradingItems = new List<Item>();
        foreach (UISlot slot in itemGrids[0].slotHandles) {
            slot.ClearSlot();
        }
    }
}
