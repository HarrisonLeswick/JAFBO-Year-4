using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneCharger : MonoBehaviour
{
    /*Current HouseNumbers:
    Main Scene: 0
    Cauldron Room: 1
    */
    
    public int houseNumber;
    private bool manualCheck = false;

    //Differe door types available automatic tps you manual needs and additional E press
    public enum DoorType
    {
        Automatic,
        Manual
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
}
