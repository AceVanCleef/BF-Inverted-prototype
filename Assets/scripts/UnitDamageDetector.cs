using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDamageDetector : MonoBehaviour {

    public int hazardDamageTaken = 25;

    void OnCollisionEnter2D(Collision2D col)
    {

        if (tag.Equals("Player") && col.gameObject.tag == "BioHazardDamageCircle")
        {
            GetComponent<UnitHealth>().sufferDamage(hazardDamageTaken);
        }
        else if (tag.Equals("Enemy") && col.gameObject.tag == "AtomicHazardDamageCircle")
        {
            GetComponent<UnitHealth>().sufferDamage(hazardDamageTaken);
        }

    }
}
