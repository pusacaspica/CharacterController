using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Rigidbody projectile;
    public Rigidbody gun;
    public Transform tip;
    public float gunVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gun != null){
            if(Input.GetButtonDown("Fire1")){
                Rigidbody shot = Instantiate(projectile, tip.position, tip.rotation);
                shot.velocity = transform.TransformDirection(new Vector3(0, 0, gunVelocity * Time.deltaTime));
            }
        }
    }
}
