using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

    // Temp
    public int numPlayers = 0;

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.GetComponent<PlayerController>() != null) {
            numPlayers++;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.GetComponent<PlayerController>() != null) {
            numPlayers--;
        }
    }
}
