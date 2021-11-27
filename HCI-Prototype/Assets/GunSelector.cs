using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GunSelector : MonoBehaviour
{
    Color inactivePanelColor;
    Color activePanelColor;
    Color activeTextColor;
    Color inactiveTextColor;
    public void Start()
    {
        inactiveTextColor = new Color(0, 255, 255);
        inactivePanelColor = new Color(0, 100, 190);
        activeTextColor = new Color(0, 45, 125);
        activePanelColor = new Color(0, 255, 255);
        GunSelectionPublisher.SelectWeapon?.AddListener(Select);
    }

    public void Select(string selectedPanel)
    {
        Debug.Log(selectedPanel + " Selected " + transform.tag);
        if (transform.tag.Equals(selectedPanel))
        {
            Debug.Log("was equal");
            Text[] text = transform.GetComponentsInChildren<Text>();
            Debug.Log(text[0].color);
            foreach (Text t in text)
                t.color = activeTextColor;
            transform.GetComponent<Image>().color = new Color(activePanelColor.r, activePanelColor.g, activePanelColor.b);
        }
        else
        {
            Debug.Log("was not equal");
            Text[] text = transform.GetComponentsInChildren<Text>();
            foreach (Text t in text)
                t.color = inactiveTextColor;
            transform.GetComponent<Image>().color = new Color(inactivePanelColor.r, inactivePanelColor.g, inactivePanelColor.b); ;
        }
    }
    public void OnDestroy()
    {
        GunSelectionPublisher.SelectWeapon.RemoveListener(Select);
    }
}
