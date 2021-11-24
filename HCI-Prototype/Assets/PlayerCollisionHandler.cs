using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    public static UnityEvent BulletHit;
    public static UnityEvent HealthPickup;
    public static UnityEvent ArmorPickup;
    public static UnityEvent CaptureF1;
    public static UnityEvent CaptureF2;

    private void Start()
    {
        BulletHit = new UnityEvent();
        HealthPickup = new UnityEvent();
        ArmorPickup = new UnityEvent();
        CaptureF1 = new UnityEvent();
        CaptureF2 = new UnityEvent();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            BulletHit?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HealthPickup")
        {
            HealthPickup?.Invoke();
        }
        else if (other.tag == "ArmorPickup")
        {
            ArmorPickup?.Invoke();
        }
        else if (other.tag == "ObjectiveF1")
        {
            CaptureF1?.Invoke();
        }
        else if (other.tag == "ObjectiveF2")
        {
            CaptureF2?.Invoke();
        }
    }
}
