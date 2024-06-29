using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    //[SerializeField] private UIController uiController;
    //[SerializeField] private EquipmentData weaponData;
    //[SerializeField] private Transform weaponInHand;
    //[SerializeField] private Transform weaponHolder;
    //[SerializeField] private bool isLeftHandSlot;
    //[SerializeField] private bool isRightHand;
    //private Animator anim;
    //private GameObject currentWeaponInHand;
    //private GameObject currentWeaponHolder;
    //private InputHandler inputHandler;

    //private bool hasWeapon = false;
    //private void Awake()
    //{
    //    InputHandler.onSwordDraw += HandleSwordDraw;
    //}
    //private void OnDestroy()
    //{
    //    InputHandler.onSwordDraw -= HandleSwordDraw;
    //}
    //private void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    inputHandler = GetComponent<InputHandler>();
    //}
  
    //public void PickUpWeapon(EquipmentData equip)
    //{
    //    if (currentWeaponInHand != null)
    //    {
    //        Destroy(currentWeaponInHand);
    //    }
    //    currentWeaponInHand = Instantiate(equip.prefab);
    //    SetWeaponTransform(currentWeaponInHand.transform, weaponInHand);
    //    inputHandler.IsSwordDrawn = true;

    //    anim.SetInteger("weaponType",(int)equip.equipType);
    //    anim.SetInteger("Stance", (int)Stance.IdleCombat);
    //    hasWeapon = true;
    //    weaponData = equip;
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    Weapon weapon = other.GetComponent<Weapon>();
    //    if(weapon == null)
    //    {
    //        return;
    //    }
    //    uiController.ShowText("Press E to Equip");
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    Weapon weapon = other.GetComponent<Weapon>();
    //    if (weapon == null)
    //    {
    //        return;
    //    }
    //    uiController.ShowText("");
    //}
    //public void HandleSwordDraw(bool isDraw)
    //{
    //    if (hasWeapon)
    //    {
    //        if (!inputHandler.IsSwordDrawn)
    //        {
    //            anim.SetTrigger("ModeOn");
    //            anim.SetInteger("Mode", (int)Mode.StoreWeapon);
    //        }
    //        else if (inputHandler.IsSwordDrawn)
    //        {
    //            anim.SetTrigger("ModeOn");
    //            anim.SetInteger("Mode", (int)Mode.DrawWeapon);
    //        }
    //    }
    //}
    //public void HandleStace()
    //{
    //    if (!inputHandler.IsSwordDrawn)
    //    {
    //       anim.SetInteger("weaponType", 0);
    //        anim.SetInteger("Stance", (int)Stance.Idle);
    //        anim.SetTrigger("StateOn");
    //    }
    //    else
    //    {
    //        anim.SetInteger("weaponType", (int)weaponData.equipType);
    //        anim.SetInteger("Stance", (int)Stance.IdleCombat);
    //        anim.SetTrigger("StateOn");
    //    }
    //    anim.SetInteger("Mode", 0);
    //}
    //public bool HaveWeapon()
    //{
    //    return hasWeapon;
    //}
    //public void DrawWeapon()
    //{
    //    Destroy(currentWeaponHolder);
    //    currentWeaponInHand = Instantiate(weaponData.prefab);
    //    SetWeaponTransform(currentWeaponInHand.transform, weaponInHand);
    //}
    //public void StoreWeapon()
    //{
    //    Destroy(currentWeaponInHand);
    //    currentWeaponHolder = Instantiate(weaponData.prefab);
    //    SetWeaponTransform(currentWeaponHolder.transform, weaponHolder);
    //}
    //private void SetWeaponTransform(Transform weaponTransform, Transform parentTransform)
    //{
    //    weaponTransform.SetParent(parentTransform);
    //    weaponTransform.localPosition = Vector3.zero;
    //    weaponTransform.localRotation = Quaternion.identity;
    //    weaponTransform.localScale = Vector3.one;
    //}
}