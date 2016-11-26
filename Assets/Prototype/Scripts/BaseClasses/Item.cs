using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Item : MonoBehaviour, IInventoryItem {
    protected PlayerController owner;
    protected GameObject itemPrefab;
    [SerializeField]
    private Sprite sprite;

    public bool isEquipped = false;

    public Sprite GetSprite() {
        return sprite;
    }

    public void OnPickup(PlayerController owner) {
        // gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.SetActive(false);
        itemPrefab = gameObject;
        this.owner = owner;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnDrop() {
        gameObject.SetActive(true);
        gameObject.transform.position = owner.transform.position + owner.transform.forward * 2.0f;
        owner = null;
        isEquipped = false;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null; // gun only .. should probably move to the gun class OnDrop();
    }

    public abstract bool OnUse();

    
}



