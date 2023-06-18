using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotDestroy : MonoBehaviour
{
    public int door = -1;
    public static doNotDestroy Instance = null;

    private void Awake() { 
    // If there is an instance, and it's not me, delete myself.
    
    if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
    }
   // Game object with the script will exist even if the scene is changed
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
