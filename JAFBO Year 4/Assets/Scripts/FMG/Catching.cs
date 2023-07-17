using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catching : MonoBehaviour
{

    private bool fishOnLine=false;
    private int taps = 1;

    // Update is called once per frame
    void Update()
    {
        //manual Fish spawning, will be done by joey code later and moved to a simple start function rather than on space
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("FishTimer");
            fishOnLine = true;
        }

        //if activly reeling in fish
        if(fishOnLine)
        {
            //tap difficulty can be altered based on fish rarity or something later for now 40 taps
            if(taps < 41)
            {
                //forcing player to alternate between right and left arrow taps
                if(Input.GetKeyDown(KeyCode.RightArrow) && taps%2 == 0)
                {
                    Debug.Log("Right");
                    taps += 1;
                }

                else if(Input.GetKeyDown(KeyCode.LeftArrow) && taps%2 == 1)
                {
                    Debug.Log("Left");
                    taps += 1;
                }
            }
            //once fish is caught reset things and trigger ay caught fish things to be later implemented
            else
            {
                Debug.Log("FEESH");
                taps = 1;
                StopCoroutine("FishTimer");
                fishOnLine = false;
            }
            
        }
    }

    //fsh on line timer (currently 5 seconds) simply waits and will make the player lose the fish if they take too long
    IEnumerator FishTimer()
    {
        Debug.Log("Fish Time Started");
        yield return new WaitForSeconds(5);
        Debug.Log("Time up");
        fishOnLine = false;
        taps = 1;
    }

    
}
