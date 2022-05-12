using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health,damagePower, walkSpeed, rotSpeed;
    Vector3 speed, lookAt, rotDirection, currentPos;
    private Transform targetToFollow;

    // Start is called before the first frame update
    void Start()
    {
        targetToFollow = GameObject.Find("Player").transform;
        walkSpeed = 1.5f;
        rotSpeed = 1f;
        health = 20f;   
    }

    // Update is called once per frame
    void Update()
    {
        lookAt = new Vector3(targetToFollow.position.x, this.transform.position.y, targetToFollow.position.z);
        rotDirection = lookAt - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(rotDirection), Time.deltaTime * rotSpeed);
        this.transform.Translate(new Vector3(0, 0, walkSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision col)
    {

        /*TODO
         * get weapon/bullet/thing damage and take off from health
         * when 0 then destroy
         * 
         * ** for this the enemy health (and other details like weakness, weapon type, etc) can be store in a xml liek file?
         */

        switch(col.gameObject.layer)
        {
            case 3:
                //layer - "Bullet"
                DamageCheck(col.gameObject.GetComponent<Bullets>().Damage);
                break;
            default:
                break;
        }

    }

    protected void DamageCheck(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
