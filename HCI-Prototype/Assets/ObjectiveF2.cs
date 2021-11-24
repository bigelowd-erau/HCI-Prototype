using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveF2 : MonoBehaviour
{
    bool captured = false;
    public static UnityEvent CapturedF2;
    private void Start()
    {
        CapturedF2 = new UnityEvent();
        PlayerCollisionHandler.CaptureF2.AddListener(Capture);
    }
    private void OnDisable()
    {
        PlayerCollisionHandler.CaptureF2.RemoveListener(Capture);
    }
    private void Capture()
    {
        if (!captured)
        {
            captured = true;
            CapturedF2?.Invoke();
        }
    }
}
