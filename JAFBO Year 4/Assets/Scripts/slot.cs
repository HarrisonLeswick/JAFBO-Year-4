using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        GameObject dropped = eventData.pointerDrag;
        Debug.Log(dropped.tag);

        pickup pickup = dropped.GetComponent<pickup>();
        pickup.parentAfterDrag = transform;
        
        Debug.Log("On drop");
    }
}
