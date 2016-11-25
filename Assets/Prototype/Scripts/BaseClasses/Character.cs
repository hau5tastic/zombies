using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour {

    protected Transform selfTransform;
    protected Rigidbody selfRigidbody;

    public const float maxHealth = 100.0f;
    public float health = 100.0f;
    public float linearSpeed = 5.0f; // Units per second
    public float angularSpeed = 180.0f; // Degrees per second

    protected virtual void Awake() {
        // Cache components for speed and efficiency
        selfTransform = transform;
        selfRigidbody = GetComponent<Rigidbody>();

        // Temp: Prevent rigidbody from tipping over 
        selfRigidbody.freezeRotation = true;
    }

    protected virtual void MoveForward(float scale) {
        // selfRigidbody.AddForce(Vector3.forward * linearSpeed * scale, ForceMode.VelocityChange);
        selfTransform.Translate(Vector3.forward * linearSpeed * scale * Time.deltaTime);
    }

    protected virtual void MoveRight(float scale) {
        // selfRigidbody.AddForce(Vector3.right * linearSpeed * scale, ForceMode.VelocityChange);
        selfTransform.Translate(Vector3.right * linearSpeed * scale * Time.deltaTime);
    }

    protected virtual void RotateRight(float scale) {
        selfTransform.Rotate(Vector3.up * angularSpeed * scale * Time.deltaTime);
    }


}
