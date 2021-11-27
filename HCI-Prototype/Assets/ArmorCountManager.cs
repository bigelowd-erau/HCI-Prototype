using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ArmorCountManager : MonoBehaviour
{
    private int startingArmor = 50;
    private int curArmor = 50;
    public static UnityEvent TakeHealthDamage;

    // Start is called before the first frame update
    void Start()
    {
        TakeHealthDamage = new UnityEvent();
        PlayerCollisionHandler.BulletHit.AddListener(TakeDamage);
        RespawnManager.Respawn.AddListener(Respawn);
        PlayerCollisionHandler.ArmorPickup.AddListener(AddArmor);
    }
    private void OnDestroy()
    {
        PlayerCollisionHandler.BulletHit.RemoveListener(TakeDamage);
        RespawnManager.Respawn.RemoveListener(Respawn);
        PlayerCollisionHandler.ArmorPickup.RemoveListener(AddArmor);
    }
    private void UpdateArmorCount()
    {
        this.GetComponent<Text>().text = curArmor.ToString();
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
            UpdateArmorCount();
        }
    }
    private void AddArmor()
    {
        if (curArmor < startingArmor)
        {
            curArmor += 10;
            UpdateArmorCount();
        }
    }
    private void Respawn()
    {
        curArmor = startingArmor;
        UpdateArmorCount();
    }
}
