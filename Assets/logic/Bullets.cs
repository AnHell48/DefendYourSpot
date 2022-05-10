using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(new Vector3(0,0,1* 5f * Time.deltaTime));
        Debug.Log(this.transform.position.z);
    }
}
