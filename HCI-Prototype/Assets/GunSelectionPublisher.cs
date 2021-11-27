using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunSelectionPublisher : MonoBehaviour
{
    public static MyStringEvent SelectWeapon;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon = new MyStringEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectWeapon?.Invoke("1");
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectWeapon?.Invoke("2");
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectWeapon?.Invoke("3");
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SelectWeapon?.Invoke("4");
        if (Input.GetKeyDown(KeyCode.G))
            SelectWeapon?.Invoke("G");
    }
}

public class MyStringEvent : UnityEvent<string>
{
}
