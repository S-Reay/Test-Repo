using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Missile : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float rechargeTime;
    public GameObject nearestEnemy;
    public bool noTarget;

    private void Start()
    {
        Destroy(gameObject, 10f);   //Bullet self destructs after 10 seconds to avoid buildup of bullets
        noTarget = true;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.position += transform.forward * speed * Time.deltaTime;   //bullet constatnly moves forward

        if (nearestEnemy != null)
        {
            Quaternion lookOnLook = Quaternion.LookRotation(nearestEnemy.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, rotateSpeed * Time.deltaTime);
        }
        else
        {
            noTarget = true;
        }

        foreach (var enemy in GameObject.FindGameObjectsWithTag("Minion"))
        {
            if (noTarget)
            {
                nearestEnemy = enemy;
                noTarget = false;
            }
            else if (Vector3.Distance(enemy.transform.position, transform.position) < Vector3.Distance(nearestEnemy.transform.position, transform.position))
            {
                nearestEnemy = enemy;
            }
        }
    }
}
