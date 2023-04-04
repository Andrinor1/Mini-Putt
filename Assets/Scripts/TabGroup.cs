using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> pagesToSwap;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
            tabButtons = new List<TabButton>();

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
            button.background.sprite = tabHover;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < pagesToSwap.Count; i++)
            if (i == index)
                pagesToSwap[i].SetActive(true);
            else
                pagesToSwap[i].SetActive(false);
    }

    public void ResetTabs(bool hardReset = false)
    {
        if (hardReset)
        {
            selectedTab = null;

            for (int i = 0; i < pagesToSwap.Count; i++)
                pagesToSwap[i].SetActive(false);
        }


        foreach (TabButton button in tabButtons)
        {
            if (selectedTab == button)
                continue;

            button.background.sprite = tabIdle;
        }
    }
}
