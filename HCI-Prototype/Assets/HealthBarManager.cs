using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    private int startingHealth = 100;
    private int curHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCollisionHandler.HealthPickup.AddListener(Heal);
        ArmorBarManager.TakeHealthDamage.AddListener(TakeDamage);
    }
    private void OnDisable()
    {
        PlayerCollisionHandler.HealthPickup.RemoveListener(Heal);
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
            Die();
    }
    private void Heal()
    {
        if (curHealth < startingHealth)
        {
            curHealth += 10;
            UpdateHealthBar();
        }
    }
    private void Die()
    {
        //go to deploy menu
    }
}
