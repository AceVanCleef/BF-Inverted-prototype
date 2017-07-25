using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //Classes need to be serialized in order to make its public fields visible in Unity's inspector.
public class Boundary2D   //no ": MonoBehavior" because this class doesn't need the given functions such as Update(), Start(), etc.
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController2D : MonoBehaviour {

    public float speed;
    public Boundary2D boundary;

    void FixedUpdate()
    {
        //source "Input.GetAxis": https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rigidBody.velocity = movement;
        rigidBody.AddForce(movement);

        rigidBody.position = new Vector2(
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidBody.position.y, boundary.yMin, boundary.yMax)
            );
    }

    /********************************* shooting a bolt *********************************/
    public GameObject shot;
    //public GameObject shotSpawn;
    public Transform shotSpawn; //Unity automatically gets the Transform property of GameObject shotSpawn.

    public float fireRate; //= 0.5f;
    private float newFire = 0.0f;   //when the next shot can be fired (in seconds)

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > newFire)
        {
            newFire = Time.time + fireRate;
            GameObject projectile = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;

            Vector2 direction = projectile.GetComponent<ProjectileMover2D>().getDirectionTowardsMousePos();
            direction.Normalize();
            projectile.GetComponent<ProjectileMover2D>().setDirection2D(direction);



            //when you want to get a reference to the shot object, see this:
            //https://docs.unity3d.com/ScriptReference/Input.GetButton.html
        }
    }
}
