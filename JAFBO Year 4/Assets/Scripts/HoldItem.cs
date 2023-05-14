using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script goes on the player and basically handles the mini-inventory of the players hands
//tracking the state of if an item is held and allowing you to discard it
public class HoldItem : MonoBehaviour
{
    private bool holdingItem;

    void Update()
    {
        //left control to discard (felt like having interact also be discard may lead to accidental discarding)
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            //if there is a discardable item within the player objecs children
           if(GetComponentInChildren<Discard>() != null)
           {
            //discard it and update the hands to be empty
                GetComponentInChildren<Discard>().DiscardItem();
                holdingItem = false;
           }
        }
    }

    //basic getter setter for hands state
    public void SetHoldingItem(bool status)
    {
        holdingItem = status;
    }

    public bool GetHoldingItem()
    {
        return holdingItem;
    }
}
