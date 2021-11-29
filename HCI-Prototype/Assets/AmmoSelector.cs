using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AmmoSelector : MonoBehaviour
{
    Color inactivePanelColor = new Color(0f, 0.392156862745098f, 0.7450980392156863f);
   Color activePanelColor = new Color(0f, 0.9372549019607843f, 1f);
    Color activeTextColor = new Color(0f, 0.1764705882352941f, 0.4901960784313725f);
    Color inactiveTextColor = new Color(0f, 1f, 1f);
    public void Start()
    {
        GunCustSelectionPublisher.SelectAmmo.AddListener(Select);
        Select("1");
    }

    public void Select(string selectedPanel)
    {
       // Debug.Log(selectedPanel + " Selected " + transform.tag);
        if (transform.tag.Equals(selectedPanel))
        {
            /*Debug.Log("was equal: selected was " + selectedPanel + " panel was " + transform.tag);
            Text[] text = transform.GetComponentsInChildren<Text>();
            Debug.Log(text[0].color);
            foreach (Text t in text)
                t.color = activeTextColor;*/
            transform.GetComponent<Image>().color = activePanelColor;
        }
        else
        {
            /*Debug.Log("was not equal: selected was " + selectedPanel + " panel was " + transform.tag);
            Text[] text = transform.GetComponentsInChildren<Text>();
            foreach (Text t in text)
                t.color = inactiveTextColor;
            Color newCol = inactivePanelColor;*/
            transform.GetComponent<Image>().color = inactivePanelColor;
        }
    }
    public void OnDestroy()
    {
        GunCustSelectionPublisher.SelectAmmo.RemoveListener(Select);
    }
}
