using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static UnityEvent Die;
    private int startingHealth = 100;
    private int curHealth = 100;

    // Start is called before the first frame update
    private void Awake()
    {
        Die = new UnityEvent();
    }
    void Start()
    {
        PlayerCollisionHandler.HealthPickup.AddListener(Heal);
        RespawnManager.Respawn.AddListener(Respawn);
        ArmorBarManager.TakeHealthDamage.AddListener(TakeDamage);
    }
    private void OnDestroy()
    {
        PlayerCollisionHandler.HealthPickup.RemoveListener(Heal);
        RespawnManager.Respawn.RemoveListener(Respawn);
        ArmorBarManager.TakeHealthDamage.RemoveListener(TakeDamage);
    }
    private void UpdateHealthBar()
    {
        this.transform.localScale = new Vector3((float)curHealth / startingHealth, 1, 1);
    }

    private void TakeDamage()
    {
        curHealth -= 10;
        Debug.Log("Bullet hit");
        UpdateHealthBar();
        if (curHealth <= 0)
            Die?.Invoke();
    }
    private void Heal()
    {
        if (curHealth < startingHealth)
        {
            curHealth += 10;
            UpdateHealthBar();
        }
    }
    private void Respawn()
    {
        curHealth = startingHealth;
        UpdateHealthBar();
    }
}
