using Unity.XR.OpenVR;
using UnityEngine;

public class WeaponHoldSlot : MonoBehaviour
{
    [SerializeField] private ItemData currentWeapon;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private Transform stashPosition;
    [SerializeField] private Player player;
    private GameObject equippedWeapon;

    private void Awake()
    {
        InputHandler.onSwordDraw += HandleSwordDraw;
    }

    private void OnDestroy()
    {
        InputHandler.onSwordDraw -= HandleSwordDraw;
    }

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    public void EquipWeapon(ItemData weaponData)
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon);
        }

        if (weaponData != null && weaponData.prefab != null)
        {
            currentWeapon = weaponData;
            equippedWeapon = Instantiate(weaponData.prefab);
            player.inputHandler.IsSwordDrawn = true;
            HandleStance();
            SetWeaponTransform(holdPosition);
        }
    }

    public void SetWeaponTransform(Transform target)
    {
        equippedWeapon.transform.SetParent(target);
        equippedWeapon.transform.localPosition = Vector3.zero;
        equippedWeapon.transform.localRotation = Quaternion.identity;
        equippedWeapon.transform.localScale = Vector3.one;
    }

    public void HandleSwordDraw(bool isDraw)
    {
        if (HaveWeapon())
        {
            if (!player.inputHandler.IsSwordDrawn)
            {
                player.Anim.SetTrigger("ModeOn");
                player.Anim.SetInteger("Mode", (int)Mode.StoreWeapon);
            }
            else if (player.inputHandler.IsSwordDrawn)
            {
                player.Anim.SetTrigger("ModeOn");
                player.Anim.SetInteger("Mode", (int)Mode.DrawWeapon);
            }
            
        }
    }

    public void HandleStance()
    {
        if (!player.inputHandler.IsSwordDrawn)
        {
            player.Anim.SetInteger("WeaponType", 0);
            player.Anim.SetInteger("Stance", (int)Stance.Idle);
            player.Anim.SetTrigger("StateOn");
        }
        else
        {
            EquipmentData equipmentData = (EquipmentData)currentWeapon ;
            if (equipmentData != null)
            {
                player.Anim.SetInteger("WeaponType", (int)equipmentData.equipType);
            }
            player.Anim.SetInteger("Stance", (int)Stance.IdleCombat);
            player.Anim.SetTrigger("StateOn");
        }
        player.Anim.SetInteger("Mode", 0);
    }

    public bool HaveWeapon()
    {
        return currentWeapon != null;
    }

    public void DrawWeapon()
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon);
        }
        equippedWeapon = Instantiate(currentWeapon.prefab);
        SetWeaponTransform(holdPosition);
    }

    public void StoreWeapon()
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon);
        }
        equippedWeapon = Instantiate(currentWeapon.prefab);
        SetWeaponTransform(stashPosition);
    }

    public void RemoveWeapon()
    {
        Destroy(equippedWeapon);
        currentWeapon = null;
        player.Anim.SetInteger("WeaponType", 0);
        player.Anim.SetInteger("Stance", (int)Stance.Idle);
        player.Anim.SetTrigger("StateOn");
    }

    public GroundItem GetWeapon()
    {
        return equippedWeapon.GetComponent<GroundItem>();
    }
}
