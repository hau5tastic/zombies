using UnityEngine;
using System.Collections;

public class PlayerController : Soldier, IPlayerController, IInventory {

    UITradePanel uiTradePanel;
    Transform selfCameraTransform;
    Backpack backpack;

    // temporary state checks
    public bool dropMode = false;
    public bool tradeMode = false;
    public bool tradeable = false;

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
        backpack = GetComponent<Backpack>();
        uiTradePanel = FindObjectOfType<UITradePanel>();
        uiTradePanel.BindPlayer(this);
        uiTradePanel.gameObject.SetActive(false);
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

        // TODO: Simplify .. currently testing tho, there might be a better way to do this
        if (Input.GetKeyDown(KeyCode.I)) {
            tradeMode = false;
            uiTradePanel.gameObject.SetActive(false);
            dropMode = !dropMode;
            if (dropMode) {
                FindObjectOfType<UIQuickslotPanel>().ChangeColor(Color.red);
            } else {
                FindObjectOfType<UIQuickslotPanel>().ChangeColor(Color.white);
            }
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            if (!tradeable) return;
            dropMode = false;
            tradeMode = !tradeMode;
            if (tradeMode) {
                uiTradePanel.gameObject.SetActive(true);
                FindObjectOfType<UIQuickslotPanel>().ChangeColor(Color.yellow);
            } else {
                uiTradePanel.Refresh();
                uiTradePanel.gameObject.SetActive(false);
                FindObjectOfType<UIQuickslotPanel>().ChangeColor(Color.white);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (tradeMode) {
                uiTradePanel.AddItem(GetItem(0));
                return;
            }
            if (dropMode) DiscardItem(0);
                UseItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (tradeMode) {
                uiTradePanel.AddItem(GetItem(1));
                return;
            }
            if (dropMode) DiscardItem(1);
                UseItem(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (tradeMode) {
                uiTradePanel.AddItem(GetItem(2));
                return;
            }
            if (dropMode) DiscardItem(2);
                UseItem(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            if (tradeMode) {
                uiTradePanel.AddItem(GetItem(3));
                return;
            }
            if (dropMode) DiscardItem(3);
                UseItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            if (tradeMode) {
                uiTradePanel.AddItem(GetItem(4));
                return;
            }
            if (dropMode) DiscardItem(4);
                UseItem(4);
        }
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
    public Item GetItem(int index) {
        return backpack.GetItem(index);
    }

    void OnCollisionEnter(Collision col) {
        // TODO: use tags
        Item item = col.gameObject.GetComponent<Item>();
        if (item != null && item.isActiveAndEnabled && !item.isEquipped) {
            AddItem(item);
        }
    }

    void OnTriggerEnter(Collider col) {
        // Temporary check
        SafeZone zone = col.GetComponent<SafeZone>();
        if (zone != null) {
            if (zone.numPlayers == 1) tradeable = true;
        }
    }

    void OnTriggerExit(Collider col) {
        // Temporary check
        if (col.GetComponent<SafeZone>() != null) {
            tradeable = false;
            uiTradePanel.gameObject.SetActive(false);
            FindObjectOfType<UIQuickslotPanel>().ChangeColor(Color.white);
        }
    }

    public override void Equip(Gun gun) {
        base.Equip(gun);
        currentGun.transform.parent = selfCameraTransform;
    }

    public override void Unequip() {
        base.Unequip();
    }

    public Backpack GetBackpack() {
        return backpack;
    }

}
