using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject GameplayUI;
    [SerializeField] private GameObject GunCustUI;
    [SerializeField] private GameObject DeploymentUI;
    [SerializeField] private GameObject LobbyUI;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //gameplay screen active
            //open gun cust screen
            if (GameplayUI.activeInHierarchy)
            {
                Debug.Log("Opening GunCustUI");
                GunCustUI.SetActive(true);
                GameplayUI.SetActive(false);
            }
            //gun cust screen active
            //open gameplay screen
            else if (GunCustUI.activeInHierarchy)
            {
                Debug.Log("Closing GunCustUI");
                GameplayUI.SetActive(true);
                GunCustUI.SetActive(false);
            }
        }
    }
    private void OnDeath()
    {
        HealthBarManager.Die.RemoveListener(OnDeath);
        DeploymentUI.SetActive(true);
        GunCustUI.SetActive(false);
        GameplayUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Deploy()
    {
        DeploymentUI.SetActive(false);
        GameplayUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        HealthBarManager.Die.AddListener(OnDeath);
    }
    public void ReturnToLobby()
    {
        DeploymentUI.SetActive(false);
        LobbyUI.SetActive(true);
    }
    public void GoToDeployment()
    {
        DeploymentUI.SetActive(true);
        LobbyUI.SetActive(false);
    }
    private void OnDestroy()
    {
    }
}
