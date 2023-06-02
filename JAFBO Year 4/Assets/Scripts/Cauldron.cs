using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CauldronState
{
    void MeterUpdate();
    void SwapState();
}

public class Simmer : CauldronState
{
    Cauldron cRef;

    public Simmer(Cauldron c)
    {
        cRef = c;
    }

    public void MeterUpdate()
    {
        cRef.AdjustEnergy(cRef.drainRates[0] * Time.deltaTime);
        cRef.AdjustBoilOver(cRef.drainRates[2] * Time.deltaTime);
    }

    public void SwapState()
    {
        cRef.SetState(cRef.stirring);
    }
}

public class Stir : CauldronState
{
    Cauldron cRef;

    public Stir(Cauldron c)
    {
        cRef = c;
    }

    public void MeterUpdate()
    {
        cRef.AdjustEnergy(-cRef.drainRates[1] * Time.deltaTime);
        cRef.AdjustBoilOver(-cRef.drainRates[3] * Time.deltaTime);
    }
    public void SwapState()
    {
        cRef.SetState(cRef.simmering);
    }
}


public class Cauldron : MonoBehaviour
{
    public CauldronState currentState;
    public BoxCollider2D cauldronTrigger;

    public Simmer simmering;
    public Stir stirring;
    //use DontDestroyOnLoad or something like that so that we can initialize some values in Start
    //0/1: simmer/stir energy   2/3: simmer/stir boil
    public float[] drainRates = new float[4];


    public float Energy = 50f;
    public float BoilOverPercent = 50f;
    bool activeMode = false;


    
    // Start is called before the first frame update
    void Start()
    {
        simmering = new Simmer(this);
        stirring = new Stir(this);

        currentState = simmering;
        activeMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeMode)
        {
            UpdateMeters();
        }
    }


    public void UpdateMeters()
    {
        currentState.MeterUpdate();
    }
    public void SetState(CauldronState cState)
    {
        currentState = cState;
    }

    public void AdjustEnergy(float adjustVal)
    {
        Energy += adjustVal;
        Energy = (Energy <= 100.00) ? Energy : 100.00f;
        if(Energy <= 0f)
        {
            Debug.Log("no energy!");
            Energy = 0f;
        }
    }

    public void AdjustBoilOver(float adjustVal)
    {
        BoilOverPercent += adjustVal;
        BoilOverPercent = (BoilOverPercent >= 0f) ? BoilOverPercent : 0f;
        if (BoilOverPercent >= 100f)
        {
            Debug.Log("KABOOM! your potion has exploded :O");
            activeMode = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.SwapState();
        Debug.Log("Stirring the potion");
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        currentState.SwapState();
        Debug.Log("Letting the potion simmer");
    }
}
