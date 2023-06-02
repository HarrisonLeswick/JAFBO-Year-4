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
    
    public int housseNumber;

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Hit the door");
        SceneManager.LoadScene (sceneBuildIndex: housseNumber);
    }
}
