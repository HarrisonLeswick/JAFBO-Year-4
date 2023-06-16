using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class pickup : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Start is called before the first frame update

    public Image image;
    public Transform parentAfterDrag;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On PointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root); // becomes a child off the UI 
        transform.SetAsLastSibling(); //so the image is closest to camera
        Debug.Log("On Begin");
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("On Drag");
        transform.position = Input.mousePosition; // tracks mouse

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("On End");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag); //goes to parent either new  ondrop object or the earlier parent
    }


}
