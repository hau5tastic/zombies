using UnityEngine;
using System.Collections;

public class Soldier : Character, IGun {

    public Transform gunMountTransform;
    public Gun currentGun;

    protected virtual void Start() {
    }

    protected virtual void Update() {

    }

    public virtual void Equip(Gun gun) {
        if (currentGun == gun) return;
        Unequip();
        currentGun = gun;
        currentGun.gameObject.SetActive(true);
        currentGun.transform.parent = gunMountTransform;
        currentGun.transform.position = gunMountTransform.position;
        currentGun.transform.rotation = gunMountTransform.rotation;
    }

    public virtual void Unequip() {
        if (currentGun == null) return;
        currentGun.transform.parent = null;
        currentGun.gameObject.SetActive(false);
        currentGun.isEquipped = false;
    }

    public void Shoot() {
        if (currentGun == null) return;
        currentGun.Shoot();
    }

    public void Reload() {
        currentGun.Reload();
    }
}
