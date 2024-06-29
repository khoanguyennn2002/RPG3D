using System;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public ItemData itemData;
    private Item item;

    private Enemy enemy;
    private void Start()
    {
        item = itemData.CreateItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        var isEnemy = other.GetComponent<Enemy>();
        if(isEnemy)
        {
            enemy = isEnemy;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        var isEnemy = other.GetComponent<Enemy>();

        if (isEnemy)
        {
            enemy = null;
        }
    }

    public Enemy GetEnemy()
    {
        return enemy;
    }    
}
