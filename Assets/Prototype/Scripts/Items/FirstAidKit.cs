using UnityEngine;
using System.Collections;

public class FirstAidKit : Item {
    public override void OnUse() {
        owner.health += 25.0f;
    }
}