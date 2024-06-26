using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    #region State
    private PlayerStateMachine StateMachine;
    public IdleState IdleState { get; private set; }
    public WalkState WalkState { get; private set; }
    public RunState RunState { get; private set; }
    public SprintState SprintState { get; private set; }
    public JumpState JumpState { get; private set; }
    public FallState FallState { get; private set; }
    public LandingState LandState { get; private set; }
    public CombatState CombatState { get; private set; }
    public AttackState AttackState { get; private set; }
    public AirAttackState AirAttackState { get; private set; }
    #endregion
    public Animator Anim { get; private set; }
    public float animSpeed { get; private set; } = 1;
    private CharacterController controller;
    private PlayerProfile playerProfile;

    private float _turnSmoothTime = 0.15f;
    private float _turnSmoothVelocity;

    public LayerMask groundLayerMask;
    private bool isGround;
    private float ySpeed;
    private float groundSpeed;

    private GroundItem item;

    private GameObject _mainCam;
    [SerializeField] private TextMeshProUGUI stateText;
    public Inventory inventory;
    public Inventory equipment;
    public InputHandler inputHandler { get; private set; }

    private void Awake()
    {
        GameManager.Instance.LoadCharacter();
        InputHandler.onPickUpWeapon += PickUpItem;
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnRemoveItem;
            equipment.GetSlots[i].OnAfterUpdate += OnAddItem;
        }
    }
    private void OnDestroy()
    {
        InputHandler.onPickUpWeapon -= PickUpItem;
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate -= OnRemoveItem;
            equipment.GetSlots[i].OnAfterUpdate -= OnAddItem;
        }
    }

    public void OnRemoveItem(InventorySlot _slot)
    {
        if(_slot.itemData == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                GameManager.Instance.statsManager.RemoveBuff(_slot.item);
                GameManager.Instance.playerProfile.UpdateUI();
                break;
            case InterfaceType.Chest:
                break;
                default: 
                break;
        }     
    }
    public void OnAddItem(InventorySlot _slot)
    {
        if (_slot.itemData == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                GameManager.Instance.statsManager.ApplyItemBuffs(_slot.item);
                GameManager.Instance.playerProfile.UpdateUI();
                WeaponHoldSlot weaponHoldSlot = GetComponentInChildren<WeaponHoldSlot>();

                switch (_slot.itemType[0])
                {
                    case ItemType.Weapon:
                        
                        break;
                    case ItemType.Glove:
                        break;
                    case ItemType.Helmet:
                        break;
                }
                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
        }
    }
    void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        Anim = GetComponent<Animator>();
        inputHandler = GetComponent<InputHandler>();
        controller = GetComponent<CharacterController>();
        playerProfile = GameManager.Instance.playerProfile;
        playerProfile.Init();
        Initialized();
    }
    void Update()
    {
        StateMachine.CurrentState.UpdateLogic();
        stateText.text = StateMachine.CurrentState.ToString();
        //if(inputHandler.IsLevelUp)
        //{
        //    playerProfile.GainXP(100);
        //    if (playerProfile.GetCurrentXP() >= playerProfile.GetCurrentLevel().XPNeedForNextLevel)
        //    {
        //        playerProfile.IncreaseLevel();
        //    }
        //    inputHandler.IsLevelUp = false;
        //}    
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.UpdatePhysics();
    }
    private void Initialized()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new IdleState(this, StateMachine);
        WalkState = new WalkState(this, StateMachine);
        RunState = new RunState(this, StateMachine);
        SprintState = new SprintState(this, StateMachine);
        JumpState = new JumpState(this, StateMachine);
        FallState = new FallState(this, StateMachine);
        LandState = new LandingState(this, StateMachine);
        CombatState = new CombatState(this, StateMachine);
        AttackState = new AttackState(this,StateMachine);
        AirAttackState = new AirAttackState(this, StateMachine);
        StateMachine.Initialize(IdleState);
    }
    public void Move(Vector3 input)
    {
        Vector3 direction = new Vector3(input.x, 0, input.z).normalized;

        if ( direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _mainCam.transform.eulerAngles.y;
            float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);
        }
        groundSpeed = controller.velocity.magnitude;
    }
    public void MoveInAir(Vector3 input)
    {
        Vector3 dir = new Vector3(input.x, 0, input.z).normalized;
        if (!isGround && dir.magnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + _mainCam.transform.eulerAngles.y;
            float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * groundSpeed * Time.deltaTime * 0.5f);
        }
    }
    public void OnAnimatorMove()
    {
        if (isGround)
        {
            Vector3 velocity = Anim.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;
            controller.Move(velocity * animSpeed);
        }
    }
    public float GetVelocityY()
    {
        return ySpeed;
    }
    public void SetVelocity(float newSpeed)
    {
        animSpeed = newSpeed;
    }
    public void HandleGravity(float gravity)
    {
        if (!isGround)
        {
            ySpeed += gravity * Time.deltaTime;
            Vector3 velocity = new Vector3(controller.velocity.x, ySpeed, controller.velocity.z);
            controller.Move(velocity * Time.deltaTime);
        }
        
    }
    public void Jump(float jumpForce, float gravity)
    {
        if (isGround)
        {
            ySpeed = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
    public bool GroundCheck()
    {
        Vector3 bottomCenter = transform.position + controller.center - new Vector3(0f, controller.height / 2f + 0.075f, 0f);
        Collider[] colliders = Physics.OverlapBox(bottomCenter, new Vector3(controller.radius * 1.5f, 0.01f, controller.radius * 1.5f), Quaternion.identity, groundLayerMask);
        isGround = colliders.Length > 0;
        Anim.SetBool("Grounded", isGround);
        return isGround;
    }
    public bool HaveWeapon()
    {
        return true;
    }
    public void CheckAttackFinish()
    {
        AttackState.FinishAttack();
    }
    public void PickUpItem()
    {
        if (item != null)
        {
            if (inventory.AddItem(new Item(item.item), 1))
            {
                Destroy(item.gameObject);
                item = null;
            }
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipment.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        var itemCollider = other.GetComponent<GroundItem>();
        if (itemCollider)
        {
            item = itemCollider;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var itemCollider = other.GetComponent<GroundItem>();
        if (itemCollider)
        {
            item = null;
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Vector3 bottomCenter = transform.position + controller.center - new Vector3(0f, controller.height / 2f + 0.075f, 0f);

    //    // Calculate the size of the box
    //    Vector3 boxSize = new Vector3(controller.radius * 1.5f, 0.01f, controller.radius * 1.5f);

    //    // Set Gizmo color based on whether the object is grounded or not
    //    Gizmos.color = isGround ? Color.green : Color.red;

    //    // Draw the wireframe of the box used for ground check
    //    Gizmos.DrawWireCube(bottomCenter, boxSize);
    //}
}