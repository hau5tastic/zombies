using UnityEngine;
using System.Collections;

public class Soldier : Character, IGun {

    public Transform gunMountTransform;
    public Gun currentGun;

    protected virtual void Start() {
        currentGun.transform.parent = gunMountTransform;
        currentGun.transform.position = gunMountTransform.position;
    }

    protected virtual void Update() {

    }

    public void Shoot() {
        currentGun.Shoot();
    }

    public void Reload() {
        currentGun.Reload();
    }
}
