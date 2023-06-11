using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class sceneCharger : MonoBehaviour, IPointerDownHandler
{
    /*Current HouseNumbers:
    Castle: 0
    Cauldron Room: 1
    Inventory Room: 2
    */
    
    public int houseNumber;
    private bool manualCheck = false;

    //Differe door types available automatic tps you manual needs and additional E press
    public enum DoorType
    {
        Automatic,
        Manual,
        OnClick
    }
    public DoorType doorType;




    void Update()
    {
        //When you have the right to change scenes (you are standing in an manual door triiger) you can press E to enter it n
        if(manualCheck == true){
            if (Input.GetKeyDown(KeyCode.E)){
                Debug.Log("On your way to scene " + houseNumber);
                SceneManager.LoadScene (sceneBuildIndex: houseNumber);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other){
        //When collision if it is automatic you instantly tp
        if( doorType == DoorType.Automatic){
            Debug.Log("On your way to scene " + houseNumber);
            SceneManager.LoadScene (sceneBuildIndex: houseNumber);
        }
        //When collision if it is manual you have the right to change scenes with a button
        if( doorType == DoorType.Manual){
            manualCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //Removes right to change scenes with a button press for automation
        if( doorType == DoorType.Manual){
            manualCheck = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData){
    //Uses unity events to check if the object has been clicked on and if it has teleport you
    // **IMPORTANT FOR USE** Any scene using a Onclick door must have a physics 2d raycaster on its camera and an event system in the hierarchy
         if( doorType == DoorType.OnClick){
            Debug.Log("On your way to scene " + houseNumber);
            SceneManager.LoadScene (sceneBuildIndex: houseNumber);
        }
    }
}
