using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private IEnumerator time;
    // Start is called before the first frame update
    void Start()
    {
        time = CycleTime();
        StartCoroutine(time);
    }

    IEnumerator CycleTime()
    {
        Debug.Log("Morning");
        yield return new WaitForSeconds(5);
        Debug.Log("Midday");
        yield return new WaitForSeconds(9);
        Debug.Log("Night");
        yield return new WaitForSeconds(6);
        Debug.Log("Resetting");
        StartCoroutine("CycleTime");
    }
}
