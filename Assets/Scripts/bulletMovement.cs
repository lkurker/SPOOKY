using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

    private Transform target;

    public float bulletSpeed;

    public bool lockOn;

    private bool collided = false;

    public void chaseTarget(Transform _human)
    {
        target = _human;
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
            Debug.Log("Hello");
            if (lockOn == true)
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

            else if (lockOn == false)
            {
                transform.position += transform.forward * Time.deltaTime * bulletSpeed;

            }
        }
        
   
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
        Debug.Log("HIT");

        if(other.transform.tag == "human")
        {
            targetHit();
        }
    }

    void targetHit()
    {
        Debug.Log("Hit???");
        Destroy(gameObject);
    }
}
