using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Rotates towards mouse position and shoots when mouse button clicked
/// </summary>
public class SP_TurretController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPoint;
    public float speed;

    void Update()
    {
        //rotate towards mouse
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 3000f))
        {
            transform.LookAt(new Vector3 (hit.point.x, transform.position.y, hit.point.z));
        }

        //shoot when clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //instantiate bullet
            Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
        }
    }
}
