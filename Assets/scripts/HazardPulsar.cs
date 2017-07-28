using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPulsar : MonoBehaviour {

    public float pulseRate = 1.0f;  //in seconds
    private float newPulse = 0.0f;

    public float maxRadius = 0.5f;
    private float currentRatius = 0.0f;

    private bool pulseActive;

	// Update is called once per frame
	void Update () {
		if (Time.time > newPulse)
        {
            pulseActive = true;
        }

        if (pulseActive)
        {
            if (currentRatius < maxRadius)
            {
                //increase radius
                currentRatius += 0.025f;
                transform.localScale += new Vector3(currentRatius, currentRatius);
            }
            else
            {
                //reset radius
                pulseActive = false;
                currentRatius = 0.0f;
                transform.localScale = new Vector3(0.1f, 0.1f);
                newPulse = Time.time + pulseRate;   //new pulse
            }
        }

        
    }
}
