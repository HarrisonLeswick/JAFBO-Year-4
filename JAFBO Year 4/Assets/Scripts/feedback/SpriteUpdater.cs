using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteUpdater : MonoBehaviour
{
    public SpriteRenderer spriteRenderer = null;
    public Image imageRenderer = null;
    public Sprite[] phases;
    public bool useSprite = true;
    private int interval;
    // Start is called before the first frame update
    void Start()
    {
        interval = 100 / (phases.Length - 1);
    }

    // Update is called once per frame
    public void UpdateSpriteToVal(float val)
    {
        if (useSprite)
        {
            //setting the sprite by doing some silly and goofy math, dw about it lmfao
            //if you are actually worried about it, i explained it in a very passive-aggressive manner here: https://docs.google.com/document/d/16Y_kvmv-cT6F_tFJ95Qupm8Yd1u2093iFchm8Ggx5D8/edit?usp=sharing 
            spriteRenderer.sprite = phases[(int)(val / interval)];
        }
        else
        {
            imageRenderer.sprite = phases[(int)(val / interval)];
        }
        
    }
}
