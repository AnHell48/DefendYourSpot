using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float bulletSpeed, bulletDistanceLimit, damage;
    private Vector3 originPos;
    public float Damage{ get { return damage; } set { damage = value; } }

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 5f;
        originPos = this.transform.position;
        bulletDistanceLimit = 40f;
        //how much damage it does
        damage = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //move bullet
        this.transform.Translate(new Vector3(0,0,1* 5f * Time.deltaTime));
        //check collition
        DistanceCheck();
    }

    private void OnCollisionEnter(Collision col)
    {
        /* TODO
         * if the layer is from enemy ... how to ? i think this is for the enemy class
         * on collition stay on that position and parent that object? (ex: arrow stuck)
         */
        //if(col.transform.gameObject.layer == "Enemie") 
        //{

        //}
        Destroy(this.gameObject);
    }
    protected void DistanceCheck()
    {
        if(Vector3.Distance(this.transform.position, originPos) > bulletDistanceLimit)
        {
            Destroy(this.gameObject);
        }
    }

}
