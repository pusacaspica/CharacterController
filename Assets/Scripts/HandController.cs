using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Rigidbody projectile;
    public Gun gun;
    public Transform tip;
    //public float gunVelocity;

    private float cooldown;
    private bool openedFire;
    // Start is called before the first frame update
    void Start()
    {
        openedFire = false;
        cooldown = 0.0f;
        gun = this.gameObject.transform.Find("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gun != null){
            if(Input.GetKeyDown(KeyCode.Alpha1)) {
                gun = this.gameObject.transform.Find("Gun").GetComponent<PistolTemplate>();
                this.gameObject.transform.Find("Gun").GetComponent<PistolTemplate>().enabled = true;
                this.gameObject.transform.Find("Gun").GetComponent<MachineGunTemplate>().enabled = false;
                this.gameObject.transform.Find("Gun").GetComponent<ShotgunTemplate>().enabled = false;
            } else if(Input.GetKeyDown(KeyCode.Alpha2)) {
                gun = this.gameObject.transform.Find("Gun").GetComponent<ShotgunTemplate>();
                this.gameObject.transform.Find("Gun").GetComponent<PistolTemplate>().enabled = false;
                this.gameObject.transform.Find("Gun").GetComponent<MachineGunTemplate>().enabled = false;
                this.gameObject.transform.Find("Gun").GetComponent<ShotgunTemplate>().enabled = true;
            } else if(Input.GetKeyDown(KeyCode.Alpha3)) {
                gun = this.gameObject.transform.Find("Gun").GetComponent<MachineGunTemplate>();
                this.gameObject.transform.Find("Gun").GetComponent<PistolTemplate>().enabled = false;
                this.gameObject.transform.Find("Gun").GetComponent<MachineGunTemplate>().enabled = true;
                this.gameObject.transform.Find("Gun").GetComponent<ShotgunTemplate>().enabled = false;
            }

            if(Input.GetButtonDown("Fire1") && (gun.gunMode == Gun.shot.SemiAuto || gun.gunMode == Gun.shot.SingleAction) && !openedFire && gun.GetComponent<PistolTemplate>().enabled){
                Rigidbody shot = Instantiate(projectile, tip.position, tip.rotation);
                shot.velocity = transform.TransformDirection(new Vector3(0, 0, gun.projectileSpeed * Time.deltaTime));
                openedFire = true;
            } else if (Input.GetButton("Fire1") && (gun.gunMode == Gun.shot.FullAuto) && !openedFire){
                Rigidbody shot = Instantiate(projectile, tip.position, tip.rotation);
                shot.velocity = transform.TransformDirection(new Vector3(0, 0, gun.projectileSpeed * Time.deltaTime));
                openedFire = true;
            } else if (Input.GetButtonDown("Fire1") && (gun.gunMode == Gun.shot.SemiAuto) && !openedFire && gun.GetComponent<ShotgunTemplate>().enabled){
                System.Random rd = new System.Random();
                for (int i = 0; i < gun.consecutiveShots; i++){
                    float spreadOnX = rd.Next(-gun.spread, gun.spread);
                    float spreadOnY = rd.Next(-gun.spread, gun.spread);
                    Rigidbody shot = Instantiate(projectile, tip.position, tip.rotation);
                    shot.velocity = transform.TransformDirection(new Vector3(spreadOnX*Time.deltaTime, spreadOnY*Time.deltaTime, gun.projectileSpeed * Time.deltaTime));
                }
                openedFire = true;
            }
            if(openedFire){
                cooldown += Time.deltaTime;
                if(cooldown >= gun.cooldown){
                    cooldown = 0.0f;
                    openedFire = false;
                }
            }
        }
    }
}
