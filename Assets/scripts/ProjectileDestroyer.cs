using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        ProjectileBounceTracker bounceTracker = col.gameObject.GetComponent<ProjectileBounceTracker>();

        if(col.gameObject.tag == "Projectile" || col.gameObject.tag == "EnemyProjectile")
        {
            if (tag.Equals("Obstacle"))
            {
                bounceTracker.incrementCurrentBounceCount();
            }

            if (bounceTracker.getCurrentBounceCount() >= bounceTracker.getMaxBounceCount())
            {
                Destroy(col.gameObject);
            }
        }
        

    }
}
