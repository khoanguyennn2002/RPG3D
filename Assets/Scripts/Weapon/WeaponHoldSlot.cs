using UnityEngine;

public class WeaponHoldSlot : MonoBehaviour
{
   [SerializeField] private ItemData currentWeapon;
   [SerializeField] private Transform holdPosition;
   [SerializeField] private Transform stashPosition;
    private GameObject equippedWeapon;
    public void EquipWeapon(ItemData weaponData)
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon);
        }

        if (weaponData != null && weaponData.prefab != null)
        {
            equippedWeapon = Instantiate(weaponData.prefab, holdPosition.position, holdPosition.rotation, holdPosition);
            currentWeapon = weaponData;
        }
    }
    public void PositionWeapon(Transform target)
    {
        equippedWeapon.transform.SetParent(target);
        equippedWeapon.transform.localPosition = Vector3.zero;
        equippedWeapon.transform.localRotation = Quaternion.identity;
    }    
}