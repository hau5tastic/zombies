using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour, IInventoryItem {
    protected PlayerController owner;
    protected GameObject itemPrefab;
    public Sprite sprite;

    public virtual void OnPickup(PlayerController owner) {
        gameObject.GetComponent<Renderer>().enabled = false;
        itemPrefab = gameObject;
        this.owner = owner;
    }
    public abstract void OnUse();
}



