using UnityEngine;
using System.Collections;

// Base for a gun prefab

[RequireComponent(typeof(Mesh))]
public class Gun : MonoBehaviour, IGun {

    private Transform selfTransform;
    public Transform barrelExit;
    public GameObject bulletPrefab;

    public int maxNumMagazine;
    public int roundsPerMagazine;
    private int maxAmmoCount;
    public int currentAmmoInMag;

    public float fireRate;
    private float fireDelay;

    [Range(0.0f, 90.0f)]
    public float bulletDeviation; // accuracy of 0 is perfect, 90 is 180 degree coverage

    void Start () {
        selfTransform = transform;
        maxAmmoCount = roundsPerMagazine * maxNumMagazine;
        fireDelay = 0.0f;
	}

    void Update() {
        fireDelay -= Time.deltaTime;
    }

    public void Shoot() {
        if (currentAmmoInMag <= 0 || fireDelay > 0) return;;
        fireDelay = fireRate;
        Instantiate(bulletPrefab, barrelExit.position, AccuracyOffset());
        --currentAmmoInMag;
    }

    private Quaternion AccuracyOffset() {
        Vector3 v = selfTransform.rotation.eulerAngles;
        v = new Vector3(v.x+Random.Range(-bulletDeviation, bulletDeviation), v.y+Random.Range(-bulletDeviation, bulletDeviation), v.z);
        return Quaternion.Euler(v);
    }

    public void Reload() {

    }
}
