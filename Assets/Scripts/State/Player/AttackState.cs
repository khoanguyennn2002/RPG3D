using Unity.VisualScripting;
using UnityEngine;

public class AttackState : PlayerGroundState
{
    private float comboTimeout = 0.75f;
    private float lastComboTime;
    private int currentCombo = 0;
    private int maxComboCount = 3;
    private bool isAttack;

    private WeaponHoldSlot weapon;

    private CharacterStatsManager statsManager;
    public AttackState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }
    public override void EnterState()
    {
        base.EnterState();
        statsManager = GameManager.Instance.statsManager;
        weapon = player.GetComponentInChildren<WeaponHoldSlot>();
        if(weapon.HaveWeapon())
        {
            SwordAttack();
        }    
        else
        {
            PunchAttack();

        }
    }

    public override void ExitState()
    {
        base.ExitState();
        player.Anim.SetInteger("Mode", 0);
        currentCombo = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Time.time > lastComboTime + comboTimeout && !isAttack)
        {
            if(!weapon.HaveWeapon())
            {
                if(movementInput.magnitude >= 0.01f)
                {
                    playerStateMachine.ChangeState(player.RunState);
                }
                else
                {
                    playerStateMachine.ChangeState(player.IdleState);
                }
            }
            else
            {
                
                playerStateMachine.ChangeState(player.CombatState);
            }
        }
        else if (player.inputHandler.IsCombatInput && !isAttack)
        {
            if(weapon.HaveWeapon())
            {
                SwordAttack();
            }
            else
            {
                PunchAttack();
            }
        }

        if (Time.time > lastComboTime + 1f)
        {
            player.inputHandler.IsCombatInput = false;
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    private void PunchAttack()
    {
        if (isAttack && !player.inputHandler.IsCombatInput) return;
        lastComboTime = Time.time;
        isAttack = true;
        player.inputHandler.IsCombatInput = false;
        player.Anim.SetInteger("Mode", (int)Mode.Punch + currentCombo);
        player.Anim.SetTrigger("ModeOn");
        currentCombo = (currentCombo + 1) % maxComboCount;
    }

    public void SwordAttack()
    {
        if (isAttack && !player.inputHandler.IsCombatInput) return;
        lastComboTime = Time.time;
        isAttack = true;
        player.inputHandler.IsCombatInput = false;
        player.Anim.SetInteger("Mode", (int)Mode.Melee + currentCombo);
        player.Anim.SetTrigger("ModeOn");
        currentCombo = (currentCombo + 1) % maxComboCount;
        
    }
    public void FinishAttack()
    {
        isAttack = false;
        ApplyDamageToEnemies(statsManager.Strength);
    }
    private void ApplyDamageToEnemies(int damage)
    {
        Collider weaponCollider = weapon.GetWeapon().GetComponent<Collider>();
        if (weaponCollider == null)
        {
            return;
        }
        Bounds weaponBounds = weaponCollider.bounds;

        Collider[] hitColliders = Physics.OverlapBox(weaponBounds.center, weaponBounds.extents, weaponCollider.transform.rotation);
        foreach (var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
    private void ApplyPunchDamageToEnemies(int damage)
    {
        // L?y collider c?a tay (gi? s? là CapsuleCollider)
        CapsuleCollider punchCollider = /* l?y t? player ho?c t? weaponHoldSlot*/;
        if (punchCollider == null)
        {
            Debug.LogError("Punch collider is missing.");
            return;
        }

        // L?y ???ng cong c?a CapsuleCollider
        Vector3 point1 = punchCollider.transform.position + punchCollider.center + Vector3.up * (punchCollider.height / 2 - punchCollider.radius);
        Vector3 point2 = punchCollider.transform.position + punchCollider.center - Vector3.up * (punchCollider.height / 2 - punchCollider.radius);

        // Tìm các collider trong vùng c?a CapsuleCollider
        Collider[] hitColliders = Physics.OverlapCapsule(point1, point2, punchCollider.radius);

        foreach (var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
