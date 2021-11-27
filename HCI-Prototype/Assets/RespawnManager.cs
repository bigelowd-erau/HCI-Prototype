using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnManager : MonoBehaviour
{
    public static UnityEvent Respawn;

    // Start is called before the first frame update
    void Start()
    {
        Respawn = new UnityEvent();
    }

    public void RespawnCall()
    {
        Respawn?.Invoke();
    }
}
