
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected float gravity = -9.81f;
    protected Vector3 movementInput { get; private set; }
    protected bool isSprintPressed { get; private set; }
    private float jumpPressTime;
    protected bool isWalking { get; private set; }
    protected bool isCombatInput { get; private set; }
    private float lastGroundedTime;
    private const float jumpCooldownDuration = 0.15f;

    protected const float runSpeed = 2f;
    protected const float walkSpeed = 1f;
    protected const float sprintSpeed = 3f;
    private const float stopSpeedThreshold = 0.001f;
    private const float speedDampingTime = 0.1f;

    WeaponHoldSlot weapon;
    

    public PlayerGroundState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
       weapon = player.GetComponentInChildren<WeaponHoldSlot>();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        HandleInput();
        player.HandleGravity(gravity);
        

        if (player.GroundCheck())
        {
            lastGroundedTime = Time.time;
        }

        if (weapon.HaveWeapon() && playerStateMachine.CurrentState != player.AttackState && player.inputHandler.IsSwordDrawn )
        {
            playerStateMachine.ChangeState(player.CombatState);
        }

        if (isCombatInput)
        {
            if(playerStateMachine.CurrentState != player.AttackState)
            {
                playerStateMachine.ChangeState(player.AttackState);
            }
        }

        if (Time.time - lastGroundedTime <= jumpCooldownDuration)
        {
            if (Time.time - jumpPressTime <= jumpCooldownDuration)
            {
                jumpPressTime = Time.time;
                playerStateMachine.ChangeState(player.JumpState);
            }
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    private void HandleInput()
    {
        movementInput = player.inputHandler.MovementInput;
        isWalking = player.inputHandler.IsWalking;
        isSprintPressed = player.inputHandler.IsSprintPressed;
        jumpPressTime = player.inputHandler.JumpPressTime;
        isCombatInput = player.inputHandler.IsCombatInput;

        float targetSpeed;

        if (isSprintPressed)
        {
            targetSpeed = movementInput.magnitude * sprintSpeed;
        }
        else if (isWalking)
        {
            targetSpeed = movementInput.magnitude * walkSpeed;
        }
        else if(playerStateMachine.CurrentState == player.AttackState)
        {
            targetSpeed = 0;
        }
        else
        {
            targetSpeed = movementInput.magnitude * runSpeed;
        }

        player.Anim.SetFloat("Vertical", targetSpeed, speedDampingTime, Time.deltaTime);

        if (player.Anim.GetFloat("Vertical") < stopSpeedThreshold)
        {
            player.Anim.SetFloat("Vertical", 0.0f);
        }
    }
}