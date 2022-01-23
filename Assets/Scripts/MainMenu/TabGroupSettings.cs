using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroupSettings : MonoBehaviour
{
    public List<GameObject> panelTabs;
    public List<TabButtonSettings> tabButtons;
    public TabButtonSettings selectedTabButton;

    //0 = idle, 1 = hover; 2 = clicked
    public Sprite[] backgroundStatus;

    public void Suscribe(TabButtonSettings btn)
    {
        if (tabButtons == null) 
            tabButtons = new List<TabButtonSettings>();

        tabButtons.Add(btn);
    }

    public void OnTabEnter(TabButtonSettings btn)
    {
        ResetTabs();
        if(selectedTabButton == null || btn != selectedTabButton)
            btn.background.sprite = backgroundStatus[1];
    }

    public void OnTabExit(TabButtonSettings btn)
    {
        ResetTabs();

    }

    public void OnTabPressed(TabButtonSettings btn)
    {
        selectedTabButton = btn;
        ResetTabs();
        btn.background.sprite = backgroundStatus[2];

        int index = btn.transform.GetSiblingIndex();
        for (int i = 0; i < panelTabs.Count; i++)
            if (i == index) panelTabs[i].SetActive(true);
            else panelTabs[i].SetActive(false);
    }

    public void ResetTabs()
    {
        foreach(TabButtonSettings buttons in tabButtons) 
        { 
            if(selectedTabButton !=null && buttons == selectedTabButton) 
                continue; 
            
            buttons.background.sprite = backgroundStatus[0];
        }

    }
}
