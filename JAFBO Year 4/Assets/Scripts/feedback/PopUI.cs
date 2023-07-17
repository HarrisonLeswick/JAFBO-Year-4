using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUI : MonoBehaviour
{
    private bool inRange = false;

    [SerializeField]
    private GameObject uiCanvas;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && inRange)
        {
            uiCanvas.SetActive(true);
        }
    }

}


