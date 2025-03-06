using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemsCount : MonoBehaviour
{
    public GameObject lastGem;
    private int gemCount = 0;

    private void FixedUpdate()
    {
        Debug.Log(gemCount);
        if (gemCount == 13)
        {
            lastGem.SetActive(true);
        }
    }

    public int GetGemCount()
    {
        return gemCount;
    }

    public void SetGemCount(int gemCount)
    {
        this.gemCount = gemCount;
    }
}
