using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveF1 : MonoBehaviour
{
    bool captured = false;
    public static UnityEvent CapturedF1;
    private void Start()
    {
        CapturedF1 = new UnityEvent();
        PlayerCollisionHandler.CaptureF1.AddListener(Capture);
    }
    private void OnDestroy()
    {
        PlayerCollisionHandler.CaptureF1.RemoveListener(Capture);
    }
    private void Capture()
    {
        if (!captured)
        {
            captured = true;
            CapturedF1?.Invoke();
        }
    }
}
