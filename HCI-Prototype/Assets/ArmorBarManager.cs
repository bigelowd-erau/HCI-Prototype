using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ArmorBarManager : MonoBehaviour
{
    private int startingArmor = 50;
    private int curArmor = 50;
    public static UnityEvent TakeHealthDamage;

    // Start is called before the first frame update
    void Start()
    {
        TakeHealthDamage = new UnityEvent();
        PlayerCollisionHandler.BulletHit.AddListener(TakeDamage);
        PlayerCollisionHandler.ArmorPickup.AddListener(AddArmor);
    }
    private void OnDisable()
    {
        PlayerCollisionHandler.BulletHit.RemoveListener(TakeDamage);
        PlayerCollisionHandler.ArmorPickup.RemoveListener(AddArmor);
    }
    private void UpdateArmorBar()
    {
        this.transform.localScale = new Vector3((float)curArmor / startingArmor, 1, 1);
    }

    private void TakeDamage()
    {
        if (curArmor <= 0)
        {
            TakeHealthDamage?.Invoke();
        }
        else
        {
            curArmor -= 10;
            //Debug.Log("Bullet hit");
            UpdateArmorBar();
        }
    }
    private void AddArmor()
    {
        if (curArmor < startingArmor)
        {
            curArmor += 10;
            UpdateArmorBar();
        }
    }
    private void Die()
    {
        //go to deploy menu
    }
}
