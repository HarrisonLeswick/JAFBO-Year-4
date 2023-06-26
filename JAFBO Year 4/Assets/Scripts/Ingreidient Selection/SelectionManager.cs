using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private List<LockIn> locks;
    // Start is called before the first frame update

    private bool clear = false;
    public void CheckAllLocked()
    {
        clear = true;
        for(int i = 0; i < locks.Count; i++)
        {
            if(!locks[i].locked)
            {
                clear = false;
            }
        }
        if(clear)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
