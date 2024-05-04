using UnityEngine;
public class Player : MonoBehaviour
{
    #region State
    private PlayerStateMachine StateMachine;
    public PlayerIdle IdleState { get; private set; }
    public PlayerWalk WalkState { get; private set; }
    public PlayerRun RunState { get; private set; }
    public PlayerSprint SprintState { get; private set; }
    public JumpState JumpState { get; private set; }
    public FallState FallState { get; private set; }
    #endregion

    public Animator Anim { get; private set; }
    public float animSpeed { get; private set; }
    private CharacterController controller;
    private PlayerProfile playerProfile;

    private float _turnSmoothTime = 0.2f;
    private float _turnSmoothVelocity;

    public LayerMask groundLayerMask;
    private bool isGround;
    private float ySpeed;
    private float groundSpeed = 0f;


    [SerializeField] private GameObject _mainCam;
   public InputHandle input { get; private set; }
    private void Awake()
    {
        GameManager.Instance.LoadCharacter();
    }
    void Start()
    {
        Anim = GetComponent<Animator>();
        input = GetComponent<InputHandle>();
        controller = GetComponent<CharacterController>();
        playerProfile = GameManager.Instance.playerProfile;
        playerProfile.Init();
        playerProfile.Test();
        Initialized();
    }
    void Update()
    {
        StateMachine.CurrentState.UpdateLogic();
        if(input.lvUP)
        {
            if (input.lvUP)
            {
                
                playerProfile.GainXP(100);
                if(playerProfile.GetCurrentXP() >= playerProfile.GetCurrentLevel().XPNeedForNextLevel)
                {
                    playerProfile.IncreaseLevel();
                }
                
             
                input.lvUP = false;
            }
        }
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.UpdatePhysics();
    }
    private void Initialized()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdle(this, StateMachine);
        WalkState = new PlayerWalk(this, StateMachine);
        RunState = new PlayerRun(this, StateMachine);
        SprintState = new PlayerSprint(this, StateMachine);
        JumpState = new JumpState(this, StateMachine);
        FallState = new FallState(this, StateMachine);
        StateMachine.Initialize(IdleState);
    }
    
    public void Move(Vector3 input,float speed,bool sprint)
    {
        Vector3 dir = new Vector3(input.x, 0, input.z).normalized;
      
        if (isGround)
        {
            if (dir.magnitude != 0)
            {
                float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + _mainCam.transform.eulerAngles.y;
                float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);
                if (!sprint)
                {
                    Anim.SetFloat("Vertical", speed, 0.2f, Time.deltaTime);
                }
                else
                {
                    Anim.SetFloat("Vertical", 3, 0.2f, Time.deltaTime);
                }
            }
            groundSpeed = controller.velocity.magnitude;
        }    
    } 
    public void MoveInAir(Vector3 input)
    {
        Vector3 dir = new Vector3(input.x, 0, input.z).normalized;
        if (!isGround && dir.magnitude >0.01f)
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
        return controller.velocity.y;
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

        }
        Vector3 velocity = new Vector3(controller.velocity.x, ySpeed, controller.velocity.z);
        controller.Move(velocity * Time.deltaTime);
    }
    public void Jump(float jumpForce,float gravity)
    {
        if(isGround)
        {
            ySpeed = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
    public bool GroundCheck()
    {
        Vector3 bottomCenter = transform.position + controller.center - new Vector3(0f, controller.height / 2f + 0.075f, 0f);
        Collider[] colliders = Physics.OverlapBox(bottomCenter, new Vector3(controller.radius * 1.5f , 0.01f, controller.radius * 1.5f), Quaternion.identity, groundLayerMask);
        isGround = colliders.Length > 0;
        Anim.SetBool("Grounded",isGround);
        return isGround;
    }
}