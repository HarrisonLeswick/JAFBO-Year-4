using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBar : MonoBehaviour
{
    //used to changne the icons in the UI
    public Image image;
    public Sprite[] faces;

    //is either 1 when we are getting energy and -1 if we are losing energy changes based on contact with cauldron collider
    private float isStirring = 1f;

    //energy level used to determine our energy
    public float energyLvl = 100f;

    //used as a public inspector vairbale for testing the speed of decay and growth
    public float decaySpeed = 1f;


    // Update is called once per frame
    void Update()
    {
        //used to take away enery 
        if(energyLvl > 0f && isStirring == -1f){
            energyLvl += (isStirring * decaySpeed);
        }
        //used to add energy
        if(energyLvl < 100f && isStirring == 1f){
            energyLvl += (isStirring * decaySpeed);
        }
        //changes image if the value crosses a thresshold 100-76 lvl 5, 75-51 lvl 4, 50-26 lvl 3, 25-1 lvl 2, 0 lvl 1
        image.sprite = faces[(int)((energyLvl + 24 ) / 25)];
    }

    //called when a trigger is entered it changes to start taking away energy 
    public void Stirring(){
        Debug.Log("+++++");
        isStirring = -1f;
    }
        //called when a trigger is entered it changes to start adding nergy 
    public void StopStirring(){
        Debug.Log("-----------");
        isStirring = 1f;
    }
}
