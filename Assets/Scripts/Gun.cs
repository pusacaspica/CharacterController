using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public string gunName;
    public Rigidbody projectile;
    public Transform barrel;
    public float projectileSpeed;
    public float cooldown = 0.0f; // used in burst weapons and semi-auto weapons
    public float fireRate; // used in burst weapons and full-auto weapons
    public float consecutiveShots; // used in shotgun-like guns with spread
    public int spread;
    public int maxBullets; // max bullets in clip
    public enum shot{
        SingleAction,
        SemiAuto,
        Burst,
        FullAuto
    }
    public shot gunMode;
    public bool isReadyToFire = true;
    public bool midFire = false;

    private float clip{
        get { return clip; }
        set { clip = value; }
    }

    // EVERYTHING BELOW IS INSTANT LEGACY CODE
    /*private float cooldownCounter;
    // Start is called before the first frame update
    void Start()
    {
        midFire = false;
        isReadyToFire = true;
        cooldownCounter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gunMode == shot.SemiAuto || gunMode == shot.Burst){
            if(!this.isReadyToFire){
                cooldownCounter += Time.deltaTime;
                if(cooldownCounter >= cooldown){
                    cooldownCounter = 0.0f;
                    isReadyToFire = true;
                }
            }
        }

        if(gunMode == shot.Burst && midFire){
            cooldownCounter += fireRate/fireRate * Time.deltaTime;
            Fire(gunMode);
            if(cooldownCounter >= fireRate * Time.deltaTime){
                midFire = false;
                isReadyToFire = false;
                cooldownCounter = 0.0f;
            }
        }

        if(gunMode == shot.FullAuto && midFire){
            cooldownCounter += fireRate/fireRate * Time.deltaTime;
            Fire(gunMode);
        }
    }

    public void Fire(shot mode){
        Rigidbody bullet;
        if(isReadyToFire){
            switch (mode){
                case shot.SingleAction:
                    bullet = Instantiate(projectile, barrel.position, barrel.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed * Time.deltaTime));
                    isReadyToFire = false;
                    break;
                case shot.SemiAuto:
                    bullet = Instantiate(projectile, barrel.position, barrel.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed * Time.deltaTime));
                    isReadyToFire = false;
                    break;
                case shot.Burst:
                    bullet = Instantiate(projectile, barrel.position, barrel.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed * Time.deltaTime));
                    midFire = true;
                    break;
                case shot.FullAuto:
                    bullet = Instantiate(projectile, barrel.position, barrel.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed * Time.deltaTime));
                    midFire = true;
                    break;
            }
        }
    }

    public void Reload(){

    }*/
}
