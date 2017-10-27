using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleShootBehaviour : MonoBehaviour
{

    //SHOOT THE PREFAB FROM THE SPECIFIC TRANSFORM
    //LEFT GUN SHOOT WITH WITH L1, LT
    //RIGHT GUN SHOOT WITH WITH R1, RT

    public float ShotCooldown = 10.0f;
    public float BulletSpeed = 2.0f;
    public float BulletTravelDistance = 2.0f;
    private Transform RightGun;
    private Transform LeftGun;
    public GameObject BulletPrefab;

    private AudioSource rightSource;
    private AudioSource leftSource;

    private bool hasShot = false;
    private bool canShoot = true;
    private float shotDelta = 0.0f;

    private bool Shoot()
    {
        rightSource.Play();
        leftSource.Play();

        if (hasShot == false)
        {
            var rightBullet = (GameObject)Instantiate(BulletPrefab, RightGun.position, RightGun.transform.rotation);
            var leftBullet = (GameObject)Instantiate(BulletPrefab, LeftGun.position, LeftGun.transform.rotation);

            rightBullet.GetComponent<Rigidbody>().velocity = RightGun.transform.forward * BulletSpeed;
            leftBullet.GetComponent<Rigidbody>().velocity = RightGun.transform.forward * BulletSpeed;

            Destroy(rightBullet, BulletTravelDistance);
            Destroy(leftBullet, BulletTravelDistance);
            return false;
        }
        return true; 
    }

    // Use this for initialization
    void Start()
    {
        rightSource = GameObject.FindGameObjectWithTag("rightgun").GetComponent<AudioSource>();
        leftSource = GameObject.FindGameObjectWithTag("leftgun").GetComponent<AudioSource>();

        RightGun = GameObject.FindGameObjectWithTag("rightgun").GetComponent<Transform>();
        LeftGun = GameObject.FindGameObjectWithTag("leftgun").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //SHOOT	
        //LIMIT SHOT BY A TIME LIMIT
        var shoot = Input.GetAxis("Shoot");

        if (hasShot == true)
        {
            shotDelta += Time.deltaTime; //START COUNTING
        }

        if (shotDelta >= ShotCooldown)
        {
            //canShoot = true; //PLAYER CAN SHOOT
            hasShot = false;
            shotDelta = 0.0f;
        }

        if (shoot > 0.0f && hasShot == false)
        {
            //canShoot = Shoot();
            hasShot = Shoot();
        }
    }
}
