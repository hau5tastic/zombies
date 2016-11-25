using UnityEngine;
using System.Collections;

public class Bandage : Item {
    public override void OnUse() {
        owner.health += 10.0f;
    }
}
