using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour, IInventoryItem {
    protected PlayerController owner;
    protected GameObject itemPrefab;
    protected Sprite sprite;

    public virtual void OnPickup(PlayerController owner) {
        this.owner = owner;
    }
    public abstract void OnUse();
}


public class Bandage : Item {

    public override void OnUse() {
        owner.health += 10.0f;
    }
}

public class FirstAidKit : Item {

    public override void OnUse() {
        owner.health += 25.0f;
    }
}

