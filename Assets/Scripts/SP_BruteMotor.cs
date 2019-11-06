using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This enemy will move towards the turret and die when shot.
/// </summary>
public class SP_BruteMotor : MonoBehaviour
{
    public GameObject turret;
    public GameObject gameManager;
    public float speed;
    public int health;

    private void Start()
    {
        turret = GameObject.Find("Turret");     //assigns the turret gameobject ot the variable based on the name
        gameManager = GameObject.Find("GameManager");     //assigns the gameManager gameobject ot the variable based on the name
        health = 5;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, turret.transform.position) > 1.5f)
        {
            //Look at turret
            transform.LookAt(turret.transform.position);
            //Move
            transform.position += transform.forward * Time.deltaTime * speed;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            
            if (health > 1)
            {
                health--;
            }
            else if (health <= 1)
            {
                //Ragdoll
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag == "Missile")
        {
            Destroy(other.gameObject);
            //Ragdoll
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            //Spawn Explosion particles
            turret.gameObject.SetActive(false);

            gameManager.GetComponent<SP_SceneManager>().GameOver();
        }
    }
}
