using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectExistanceLimiter : MonoBehaviour {

    public int maxLifeSpan = 16; //seconds

    void Start()
    {

        Destroy(gameObject, maxLifeSpan);       //gameObject == this == parent container

    }
}
