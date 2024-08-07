using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("General Information")]
    public string enemyName;          // T�n c?a k? th�
    public string description;        // M� t? v? k? th�
    public Sprite enemySprite;        // H�nh ?nh ??i di?n c?a k? th�

    [Header("Combat Statistics")]
    public int baseHealth;            // M�u c? b?n c?a k? th�
    public int attackDamage;          // S�t th??ng t?n c�ng c?a k? th�

    [Header("Experience and Level")]
    public int minExp;                // Kinh nghi?m t?i thi?u m� k? th� r?i ra
    public int maxExp;
    public int minLevel;// Kinh nghi?m t?i ?a m� k? th� r?i ra
    public int maxlevel;// C?p ?? c?a k? th�

    [Header("Attack")]
    public float attackRange;         // T?m t?n c�ng c?a k? th�
    public float attackCooldown;      // Th?i gian ch? gi?a c�c ??t t?n c�ng
}
