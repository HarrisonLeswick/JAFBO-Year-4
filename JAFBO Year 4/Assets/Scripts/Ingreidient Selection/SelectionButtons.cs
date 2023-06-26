using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionButtons : MonoBehaviour
{
    //this script should either be on the object being effected by selection buttons, or on a manager style 
    //things so that mulltiple buttons may communicate and effect the same thing properly.
    //also note this script only updates an index variable and can be used in any situation requireing selections in this way
    //whatever list you wish to be indexing with thevalue must be created in it's own script (see ingredient dsplay for example)
    
    //active selection
    public int currentSelection = 0;

    //highest number of selections possible
    [SerializeField]
    private int maxSelections;

    //goto next item in list
    public void NextSelection()
    {
        currentSelection++;
        //failsafe
        if(currentSelection >= maxSelections)
        {
            currentSelection = 0;
        }
    }

    //goto previous item in list
    public void PreviousSelection()
    {
        currentSelection--;
        //failsafe
        if(currentSelection < 0)
        {
            currentSelection = maxSelections-1;
        }
    }

    //set max number of items
    public void SetMaxSelections(int max)
    {
        maxSelections = max;
    }

    
    public int GetCurrentSelection()
    {
        return currentSelection;
    }
}
