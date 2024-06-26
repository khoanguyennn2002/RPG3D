using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Private Variables

    private bool isLevelUp;
    private bool isSwordDrawn;
    #endregion

    #region Public Properties

    public Vector3 MovementInput { get; private set; }
    public bool IsSprintPressed { get; private set; }
    public bool IsWalking { get; private set; }
    public float JumpPressTime { get; private set; }
    public bool IsCombatInput { get; set; }

    public bool IsLevelUp
    {
        get => isLevelUp;
        set => isLevelUp = value;
    }
    public bool IsSwordDrawn
    {
        get => isSwordDrawn;
        set => isSwordDrawn = value;
    }
    #endregion


    public static Action onPickUpWeapon;
    public static Action<bool> onSwordDraw;
    public static Action onShowInventory;

    [SerializeField] private LevelLoader levelLoader;

    private void Update()
    {
        // Handle player input
        
        HandleMovementInput();
        HandleSprintInput();
        HandleWalkInput();
        HandleJumpInput();
        HandleSaveInput();
        HandleLevelUpInput();
        HandleWeaponPickupInput();
        HandleSwordDrawInput();
        HandleAttackInput();
        HandleInventoryShow();
    }

    #region Input Handling

    private void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        MovementInput = new Vector3(horizontal, 0, vertical);
    }

    private void HandleSprintInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            IsSprintPressed = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            IsSprintPressed = false;
    }

    private void HandleWalkInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsWalking = !IsWalking;
        }
    }

    private void HandleJumpInput()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpPressTime = Time.time;
        }
    }

    private void HandleSaveInput()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            GameManager.Instance.SaveCharacter();
            levelLoader.LoadLevel(2);
        }
    }

    private void HandleLevelUpInput()
    {
        if (Input.GetKeyDown(KeyCode.U))
            IsLevelUp = true;
    }

    private void HandleWeaponPickupInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            onPickUpWeapon.Invoke();
        }
    }

    private void HandleSwordDrawInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            IsSwordDrawn = !IsSwordDrawn;
            onSwordDraw?.Invoke(IsSwordDrawn);
        }
    }

    private void HandleAttackInput()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetMouseButtonDown(0))
        {
            IsCombatInput = true;
        }
    }

    private void HandleInventoryShow()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            onShowInventory.Invoke();
         
        }
    }
    #endregion
}
