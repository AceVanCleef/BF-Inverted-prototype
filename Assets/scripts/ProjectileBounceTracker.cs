using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBounceTracker : MonoBehaviour {

    /* how often a projectile can bounce off obstacles */
    public int MaxBounceCount = 9;
    private int currentBounceCount = 0;

    public int getCurrentBounceCount()
    {
        return currentBounceCount;
    }

    public int getMaxBounceCount()
    {
        return MaxBounceCount;
    }

    public void incrementCurrentBounceCount()
    {
        currentBounceCount++;
    }


}
