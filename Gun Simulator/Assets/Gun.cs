using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public GameObject emptyBullet;
    public GameObject muzzleFlash;
    public Transform barrelTransform;
    public Transform emptyShotLocation;
    public Animator animator;
    public float destroyTime = 2f;
    public float shotPower = 200f;
    public float emptyBulletPower = 100f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Fire");
            //Shoot();
        }
    }

    void Shoot()
    {

        GameObject currentFlash = Instantiate(muzzleFlash, barrelTransform.position, barrelTransform.rotation);
        Destroy(currentFlash, destroyTime);
        GameObject currentBullet = Instantiate(bullet, barrelTransform.position, barrelTransform.rotation);
        currentBullet.GetComponent<Rigidbody>().AddForce(barrelTransform.forward * shotPower*1000, ForceMode.Impulse);
        Destroy(currentBullet, destroyTime);
    }

    void CasingRelease()
    {
        GameObject currentEmptyBullet = Instantiate(emptyBullet, emptyShotLocation.position, Quaternion.identity);
        currentEmptyBullet.GetComponent<Rigidbody>().AddForce(0, 5*emptyBulletPower, 3*emptyBulletPower, ForceMode.Impulse);
        Destroy(currentEmptyBullet, destroyTime);
    }
}
