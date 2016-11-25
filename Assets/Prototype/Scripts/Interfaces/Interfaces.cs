using UnityEngine;
using System.Collections;

public interface IGun {
	void Shoot();
    void Reload();
}

public interface IPlayerController {
    void HandleVerticalMovement();
    void HandleHorizontalMovement();
    void HandleRotationalMovement();
    void Fire();
}

public interface IInventoryItem {
    void OnPickup(PlayerController owner);
    void OnUse();
    Sprite GetSprite();
}

public interface IInventory {
    void AddItem(Item item);
    void DiscardItem(int index);
    void UseItem(int index);
}
