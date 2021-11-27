using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCountManager : MonoBehaviour
{
    private int startingHealth = 100;
    private int curHealth = 100;

    // Start is called before the first frame update
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
    private void UpdateHealthCount()
    {
        this.GetComponent<Text>().text = curHealth.ToString();
    }

    public void TakeDamage()
    {
        curHealth -= 10;
        Debug.Log("Bullet hit");
        UpdateHealthCount();
    }
    private void Heal()
    {
        if (curHealth < startingHealth)
        {
            curHealth += 10;
            UpdateHealthCount();
        }
    }
    private void Respawn()
    {
        curHealth = startingHealth;
        UpdateHealthCount();
    }
}
