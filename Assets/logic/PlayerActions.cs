using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private float rotSpeed, rotationDirection;
    private bool goingOtherway;
    enum RotationDir
    {
        left, right
    };
    private RotationDir leftORright;


    // Start is called before the first frame update
    void Start()
    {
        goingOtherway = false;
        rotSpeed = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    protected void PlayerControls()
    {
        //move Left & right
        if(Input.GetKey(KeyCode.D))
        {
            if ( rotationDirection <= 0)
            {
                //create a drift effect (continuos movement)
                rotationDirection+= 0.005f;
            }
            else
            {
                rotationDirection = rotSpeed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (rotationDirection >= 0)
            {
                //create a drift effect 
                rotationDirection-= 0.005f;
            }
            else
            {
                rotationDirection = -(rotSpeed * Time.deltaTime);

            }
        }

        this.transform.Rotate(new Vector3(0,rotationDirection,0));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //pew pew
            Shoot();
        }
    }

    protected void Shoot()
    {
        GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject)), this.transform.Find("ammoSpawner").transform.position,this.transform.localRotation) as GameObject;
    }
}
