using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Page> Pages = new List<Page>();
    public Page SelectedPage;

    private int pageIndex = 0;

    void Start()
    {
        SelectedPage = Pages[0];

        // only display page 1
        foreach (var page in Pages)
        {
            if (page != SelectedPage)
            {
                foreach (Transform child in page.transform)
                {
                    child.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }

    void Update()
    {
        //test
        if (Input.GetKeyUp(KeyCode.N))
        {
            NextPage();
        } else if (Input.GetKeyUp(KeyCode.P))
        {
            PreviousPage();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (getNearestEmptySlot() != null)
            {
                getNearestEmptySlot().item = (Item) ScriptableObject.CreateInstance("HealthPotion");
            }
        }
    }

    #region Page Selection
    private void NextPage()
    {
        if (pageIndex < 2)
        { 
            pageIndex++;
            SelectedPage = Pages[pageIndex];
        }
        DisplaySelectedPage(SelectedPage);
    }

    private void PreviousPage()
    {
        if (pageIndex > 0)
        { 
            pageIndex--;
            SelectedPage = Pages[pageIndex];
        }
        DisplaySelectedPage(SelectedPage);

    }


    private void DisplaySelectedPage(Page page)
    {
        foreach (var p in Pages)
        {
            if (p == page)
            {
                foreach (var slot in p.Slots)
                {
                    p.GetComponent<Renderer>().enabled = true;
                }
            } else
            {
                foreach (var slot in p.Slots)
                {
                    p.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }
    #endregion

    public Slot getNearestEmptySlot()
    {
        foreach (var page in Pages)
        {
            foreach (var slot in page.Slots)
            {
                if (slot.item == null)
                {
                    return slot;
                }
            }
        }
        return null; // inventory is full
    }
}
