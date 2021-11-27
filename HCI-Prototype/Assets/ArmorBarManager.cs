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
        RespawnManager.Respawn.AddListener(Respawn);
        PlayerCollisionHandler.ArmorPickup.AddListener(AddArmor);
    }
    private void OnDestroy()
    {
        PlayerCollisionHandler.BulletHit.RemoveListener(TakeDamage);
        RespawnManager.Respawn.RemoveListener(Respawn);
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
    private void Respawn()
    {
        curArmor = startingArmor;
        UpdateArmorBar();
    }
}
