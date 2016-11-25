using UnityEngine;
using System.Collections;

public class PlayerController : Soldier, IPlayerController, IInventory {

    Transform selfCameraTransform;
    Backpack backpack;


    protected override void Awake() {
        base.Awake();
    }

    protected override void Start() {
        base.Start();
        // Ideally there should only be one camera per player, so if networked, create a camera per player
        // Also, the camera MUST not be a component of the object, otherwise the rotations would use the object's rotations
        // attach it as a child instead
        Instantiate(Resources.Load("Prototype/PlayerCamera"), selfTransform, false);
        selfCameraTransform = GetComponentInChildren<Camera>().transform;
        currentGun.transform.parent = selfCameraTransform;
    }

    protected override void Update() {
        base.Update();

        HandleInput();
    }

    void HandleInput() {
        HandleVerticalMovement();
        HandleHorizontalMovement();
        HandleRotationalMovement();
        Fire();
    }

    public void HandleVerticalMovement() {
        float vertical = Input.GetAxis("Vertical");
        base.MoveForward(vertical);
    }

    public void HandleHorizontalMovement() {
        float horizontal = Input.GetAxis("Horizontal");
        base.MoveRight(horizontal);
    }

    public void HandleRotationalMovement() {
        float xRot = Input.GetAxis("Mouse X"); // * XSensitivity;
        float yRot = Input.GetAxis("Mouse Y"); // * YSensitivity;

        // Camera Up and Down
        selfCameraTransform.localRotation *= Quaternion.Euler(-yRot, 0, 0f);
        // Camera Rotation and Player Rotation -- Rotation speed is limited by the Character rotation speed
        RotateRight(xRot);
    }

    public void Fire() {
        if(Input.GetMouseButton(0)) {
            Shoot();
        }
    }

    public void AddItem(Item item) {
        backpack.AddItem(item);
    }

    public void DiscardItem(int index) {
        backpack.DiscardItem(index);
    }

    public void UseItem(int index) {
        backpack.UseItem(index);
    }


}
