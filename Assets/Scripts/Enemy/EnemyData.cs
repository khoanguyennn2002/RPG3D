using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("General Information")]
    public string enemyName;          // Tên c?a k? thù
    public string description;        // Mô t? v? k? thù
    public Sprite enemySprite;        // Hình ?nh ??i di?n c?a k? thù

    [Header("Combat Statistics")]
    public int baseHealth;            // Máu c? b?n c?a k? thù
    public int attackDamage;          // Sát th??ng t?n công c?a k? thù

    [Header("Experience and Level")]
    public int minExp;                // Kinh nghi?m t?i thi?u mà k? thù r?i ra
    public int maxExp;
    public int minLevel;// Kinh nghi?m t?i ?a mà k? thù r?i ra
    public int maxlevel;// C?p ?? c?a k? thù

    [Header("Attack")]
    public float attackRange;         // T?m t?n công c?a k? thù
    public float attackCooldown;      // Th?i gian ch? gi?a các ??t t?n công
}
