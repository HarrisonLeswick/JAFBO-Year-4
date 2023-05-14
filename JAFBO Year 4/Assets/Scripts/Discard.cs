using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script goes on the visually held items (they cannot actually do anything and are purely visual)
//this discard function in turn only removes that visual representation and doesn't delete the item from your inventory 
//or anything like that
public class Discard : MonoBehaviour
{
    //deletes the held gameobject
    public void DiscardItem()
    {
        Destroy(this.gameObject);
    }
}
