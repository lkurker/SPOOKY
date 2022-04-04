using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

    private Transform target;

    public float bulletSpeed;

    private int lockOn;

    private bool collided = false;



    public void chaseTarget(Transform _human, int lockOnTarget)
    {
        target = _human;

        //we will use this mechanic to determine whether the bullet locks on or not
        lockOn = lockOnTarget;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
                Debug.Log("locked on");

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
            targetHit();
        }
    }

    void targetHit()
    {
        Destroy(gameObject);
    }
}
