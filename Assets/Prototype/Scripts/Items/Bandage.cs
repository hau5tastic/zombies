using UnityEngine;
using System.Collections;

public class Bandage : Item {
    public override bool OnUse() {
        owner.health += 10.0f;
        return true;
    }
}
