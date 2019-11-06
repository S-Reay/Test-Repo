using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Bullet : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 10f);   //Bullet self destructs after 10 seconds to avoid buildup of bullets
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;   //bullet constatnly moves forward
    }
}
