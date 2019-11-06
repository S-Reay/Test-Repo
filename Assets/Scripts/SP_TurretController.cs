using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Rotates towards mouse position and shoots when mouse button clicked
/// </summary>
public class SP_TurretController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject missile;
    public GameObject bulletPoint;
    public float speed;
    public float rechargeTime;
    public float maxRechargeTime;
    public Image rechargeBar;
    public Text score;

    void Start()
    {
        rechargeTime = 0f;
        maxRechargeTime = 1.5f;
    }

    void Update()
    {
        //rotate towards mouse
        RaycastHit hit;                                                                                     //Decleare a new hit variable that stores information of what is hit
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                                        //declare a ray that is drawn from the camera uising the mouse position

        if (Physics.Raycast(ray, out hit, 3000f))                                                           //if the ray hits anything
        {
            transform.LookAt(new Vector3 (hit.point.x, transform.position.y, hit.point.z));                 //point the turret at the mouse's position
        }

        //shoot when clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))                                                               //when player clicks left mouse button
        {
            //instantiate bullet
            Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);            //spawns a bullet from the turret barrel
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && rechargeTime <= 0f)
        {
            //instantiate missile
            Instantiate(missile, bulletPoint.transform.position, bulletPoint.transform.rotation);            //spawns a missile from the turret barrel
            rechargeTime = maxRechargeTime;
        }


        if (rechargeTime > 0f)
        {
            rechargeTime -= Time.deltaTime;
        }
        rechargeBar.fillAmount = 1 - (rechargeTime / maxRechargeTime);
    }
}
