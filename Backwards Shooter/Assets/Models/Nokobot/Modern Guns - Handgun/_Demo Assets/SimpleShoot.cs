using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;


    [Header("Settings")]
    [SerializeField] 
    private float destroyTimer = 2f;
    [SerializeField] 
    private float shotPower = 500f;
    [SerializeField] 
    private float timeShoot = 1.5f;

    float timer = 0;
    AudioSource aud;
    GameManger gameManger;

    void Start()
    {
        gameManger = GameManger.instance;
        aud = GetComponent<AudioSource>();

        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (gameManger)
        {
            if (gameManger.gameState)
            {
                timer += Time.deltaTime;

                if (timer >= timeShoot)
                {
                    //Calls animation on the gun that has the relevant animation events that will fire
                    gunAnimator.SetTrigger(GameString.fire);
                    timer = 0;
                }
            }

        }
    }
  

    //This function creates the bullet behavior and Work in the pisole Animation
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        aud.Play();
        // Create a bullet and add force on it in direction of the barrel
        
        GameObject Bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Destroy(Bullet, 3f);

    }

  
}
