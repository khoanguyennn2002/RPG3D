using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment Data", menuName = "Inventory System/ItemObjects/Equipment")]
public class EquipmentData : ItemData
{
    public int levelRequire;
    public EquipType equipType;
}
