using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour {

    public List<Slot> Slots = new List<Slot>();

    void Start()
    {
        //// initialize 12 slots per page
        //for (int i = 0; i < 12; i++)
        //{
        //    Slots.Add(new Slot());
        //}

        foreach (Transform slot in transform)
        {
            //Slots.Add(slot.GetComponent<Slot>());
        }
    }
}
