using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : NetworkBehaviour {

    [SerializeField]
    RigidbodyFirstPersonController firstPersonController;

    [SerializeField]
    GameObject AssaultRifle;

    // List<Weapon> weapons = new List<Weapon>();
    List<Item> items = new List<Item>();

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
