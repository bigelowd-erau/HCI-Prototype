using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunCustSelectionPublisher : MonoBehaviour
{
    public static MyStringEvent SelectScope;
    public static MyStringEvent SelectBarrel;
    public static MyStringEvent SelectUnderBarrel;
    public static MyStringEvent SelectAmmo;
    private int scopeSelection = 1;
    private int barrelSelection = 1;
    private int underBarrelSelection = 1;
    private int ammoSelection = 1;

    // Start is called before the first frame update
    void Start()
    {
        SelectScope = new MyStringEvent();
        SelectBarrel = new MyStringEvent();
        SelectUnderBarrel = new MyStringEvent();
        SelectAmmo = new MyStringEvent();
    }

    // Update is called once per frame
    void Update()
    {
        //Scope Key
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //loops through 0-3
                scopeSelection = (scopeSelection + 1) % 4;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //loops through 0-3
                scopeSelection--;
                if (scopeSelection < 0)
                    scopeSelection = 3;
            }
            SelectScope?.Invoke(scopeSelection.ToString());
        }
        //Barrel Key
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //loops through 0-3
                barrelSelection = (barrelSelection + 1) % 4;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //loops through 0-3
                barrelSelection--;
                if (barrelSelection < 0)
                    barrelSelection = 3;
            }
            SelectBarrel?.Invoke(barrelSelection.ToString());
        }
        //Under Barrel Key
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //loops through 0-3
                underBarrelSelection = (underBarrelSelection + 1) % 4;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //loops through 0-3
                underBarrelSelection--;
                if (underBarrelSelection < 0)
                    underBarrelSelection = 3;
            }
            SelectUnderBarrel?.Invoke(underBarrelSelection.ToString());
        }
        //Ammo Key
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //loops through 0-3
                ammoSelection = (ammoSelection + 1) % 4;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //loops through 0-3
                ammoSelection--;
                if (ammoSelection < 0)
                    ammoSelection = 3;
            }
            SelectAmmo?.Invoke(ammoSelection.ToString());
        }
    }
}
