using UnityEngine;
using System.Collections;

public class FirstAidKit : Item {
    public override bool OnUse() {
        owner.health += 25.0f;
        return true;
    }
}