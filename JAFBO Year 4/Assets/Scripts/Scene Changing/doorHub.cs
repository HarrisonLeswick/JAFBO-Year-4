using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHub : MonoBehaviour
{
    //used to select how you want to spawn compared to the dorr in the inspector
    public enum Offset
    {
        Center,
        Left,
        Right,
        Up,
        Down,
        DoubleDown
    }

    //list of doors to manage in the scenes
    public GameObject[] doors;
    //list of offsets that will be matched with the doors 1 to 1 for ex you spawn offset from door 0 using offset 0
    public Offset[] offsets;

    //used to reference our end location and player
    public GameObject player;
    public int door;

    // Start is called before the first frame update
    void Awake()
    {
        //ued as reference to the main player in order to move them
        player = GameObject.FindWithTag("Player");
        //used in refrence to our final number which is pulled out of our donot destroy which carried it from the other scene
        door = GameObject.FindWithTag("DoNotDestroy").GetComponent<doNotDestroy>().door;

        //used for the first ever on awake. This lets your spawn not be affected
        if(door == -1){
            Debug.Log("Game Start");
        }
        //used to spawn if you have no offset
        else if(offsets[door] == Offset.Center){
            player.transform.position =  doors[door].transform.position;
        }
        //used to spawn if you have left offset
        else if(offsets[door] == Offset.Left){
            player.transform.position =  doors[door].transform.position + new Vector3(-1, 0, 0);
            //sets player postion to be equal to the door position and then adds your offset
        }
        //used to spawn if you have right offset        
        else if(offsets[door] == Offset.Right){
           player.transform.position =  doors[door].transform.position + new Vector3(1, 0, 0);
        }
        //used to spawn if you have up offset        
        else if(offsets[door] == Offset.Up){
            player.transform.position =  doors[door].transform.position + new Vector3(0, 1, 0);
        }
        //used to spawn if you have down offset        
        else if(offsets[door] == Offset.Down){
            player.transform.position =  doors[door].transform.position + new Vector3(0, -1, 0);
        }
        else if(offsets[door] == Offset.DoubleDown){
            player.transform.position =  doors[door].transform.position + new Vector3(0, -2, 0);
        }
    }

}
