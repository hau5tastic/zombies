using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour, IInventoryItem {
    protected PlayerController owner;
    protected GameObject itemPrefab;
    [SerializeField]
    private Sprite sprite;

    public void OnPickup(PlayerController owner) {
        // gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.SetActive(false);
        itemPrefab = gameObject;
        this.owner = owner;
    }

    public abstract void OnUse();

    public Sprite GetSprite() {
        return sprite;
    }
    
}



