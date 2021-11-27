using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationHandler : MonoBehaviour
{
    private string notificationMessage;
    float messageLifetime = 5.0f;
    bool hasMessage = false;
    public int opacity = 255;
    Color color;
    int objsCaptured = 0;
    private void Start()
    {
        color = GetComponent<Image>().color;
        if (this.tag == "ObjectiveF1")
        {
            ObjectiveF1.CapturedF1.AddListener(ObjectiveCaptured);
            notificationMessage = "ObjectiveF1 Captured";
        }
        else if (this.tag == "ObjectiveF2")
        {
            ObjectiveF2.CapturedF2.AddListener(ObjectiveCaptured);
            notificationMessage = "ObjectiveF2 Captured";
        }
        else if(this.tag =="Sector")
        {
            ObjectiveF1.CapturedF1.AddListener(ObjectiveCaptured);
            ObjectiveF2.CapturedF2.AddListener(ObjectiveCaptured);
            notificationMessage = "Sector Captured";
        }

    }
    private void OnDestroy()
    {
        PlayerCollisionHandler.CaptureF1?.RemoveListener(ObjectiveCaptured);
        PlayerCollisionHandler.CaptureF2?.RemoveListener(ObjectiveCaptured);
    }
    private void ObjectiveCaptured()
    {
        if (this.tag == "Sector")
            objsCaptured++;
        if (objsCaptured == 2 || this.tag != "Sector")
        {
            transform.GetComponentInChildren<Text>().text = notificationMessage;
            hasMessage = true;
            GetComponent<Image>().color = new Color(color.r, color.g, color.b, opacity);
        }
    }

    private void FixedUpdate()
    {
        if (hasMessage)
        {
            messageLifetime -= Time.deltaTime;
            if (messageLifetime <= 0)
                EraseMessage();
        }
    }
    private void EraseMessage()
    {
        hasMessage = false;
        messageLifetime = 5.0f;
        transform.GetComponentInChildren<Text>().text = "";
        GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0);
    }
}
