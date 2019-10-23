using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This enemy will move towards the turret and die when shot.
/// </summary>
public class SP_MinionMotor : MonoBehaviour
{
    public GameObject turret;
    public float speed;

    private void Start()
    {
        turret = GameObject.Find("Turret");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, turret.transform.position) > 1.5f)
        {
            //Look at turret
            transform.LookAt(turret.transform.position);
            //Move
            transform.position += transform.forward * Time.deltaTime * speed;
            //Maintain Y position
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

    }
}
