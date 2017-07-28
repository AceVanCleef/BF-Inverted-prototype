using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDamageDetector : MonoBehaviour {

    public int hazardDamageTaken = 25;
    
    void OnTriggerEnter2D (Collider2D col)
    {
        print(tag + " vs " + col.gameObject.tag);

        if (tag.Equals("Player") && col.gameObject.tag == "BioHazardDamageCircle")
        {
            GetComponent<UnitHealth>().sufferDamage(-hazardDamageTaken);
        }
        else if (tag.Equals("Enemy") && col.gameObject.tag == "AtomicHazardDamageCircle")
        {
            GetComponent<UnitHealth>().sufferDamage(-hazardDamageTaken);
        }

    }
}
