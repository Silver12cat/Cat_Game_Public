using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Money, Health, MaxHealth, PlayerAttack;
    public Transform attachPoint;
    public GameObject owner;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int add)
    {
        Money = Money+add;
    }

    public void SubtractMoney(int sub)
    {
        if(sub > Money)
        {
            Money = 0;
        }
        else
        {
            Money = Money - sub;
        }
    }
    public void Heal()
    {
        Health++;
    }

    public void IncreaseMaxHealth()
    {
        MaxHealth++;
    }

    public void Hurt(int damage)
    {
        if (damage > Health)
        {
            Health = 0;
        }
        else
        {
            Health = Health - damage;
        }
    }

    public void Attack()
    {

    }
    
    public bool PickupItem(GameObject obj)
    {



        switch (obj.tag)
        {
            case "Weapon":
                if (owner != null)
                {
                    attachPoint.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                    obj.transform.parent = attachPoint.transform;
                }
                return false;

            default:
                Debug.LogWarning($"WARNING: No handler implemented for tag {obj.tag}.");
                return false;
        }
    }

}
