using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

    private Transform target;

    public float bulletSpeed;

    private int lockOn;

    private bool collided = false;
    public int bulletPower;

    //public reference to the explosion gameObject
    public GameObject explosion;



    public void chaseTarget(Transform _human, int lockOnTarget, int firePower)
    {
        target = _human;

        //we will use this mechanic to determine whether the bullet locks on or not
        lockOn = lockOnTarget;

        //passing on the power of the bullets to this instance of the object
        bulletPower = firePower;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        if(collided == false)
        {
            
            if (lockOn == 1)
            {
                

                Vector3 dir = target.position - transform.position;
                float distanceThisFrame = bulletSpeed * Time.deltaTime;

                /*if (dir.magnitude <= distanceThisFrame)
                {
                    targetHit();
                    return;
                }*/

                //if the bullet has not yet hit an object


                transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            }

            else if (lockOn == 0)
            {
                transform.position += transform.forward * Time.deltaTime * bulletSpeed;

            }
        }
        
   
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
        

        if(other.transform.tag == "human")
        {
            //condition for if this gameObject is a missile
            if (this.transform.tag == "missile")
            {
                Instantiate(explosion, this.transform.position, this.transform.rotation);
                Debug.Log("BOOM");
                targetHit();
            }
            else
            {
                targetHit();
            }
        }
    }

    void targetHit()
    {
        Destroy(gameObject);
    }
}
