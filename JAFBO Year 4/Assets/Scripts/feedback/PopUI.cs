using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUI : MonoBehaviour
{
    private bool inRange = false;

    //UI to pop
    [SerializeField]
    private GameObject uiCanvas;


    //when player in range
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    //when player leaves range
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    //pop UI if interacted with
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && inRange)
        {
            uiCanvas.SetActive(true);
        }
    }

}


