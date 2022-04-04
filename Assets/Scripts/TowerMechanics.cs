using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMechanics : MonoBehaviour
{

    private Transform target;
    public float rotationSpeed;
    [Header("TowerAttributes")]

    public float fireRate;
    private float fireCountdown = 0f;
    public float towerRange;
    public GameObject bulletPrefab;
    public Transform firePoint;

    //public bool to determine if this specific tower locks on to their target or not
    public bool towerLockOn;
    private int lockOn;
    
    

    // Start is called before the first frame update
    void Start()
    {
        if(towerLockOn == true)
        {
            lockOn = 1;
        }
        else if(towerLockOn == false)
        {
            lockOn = 0;
        }
        

        //updating our target every half second
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        //setting an array of humans that our towers will attempt to find and lock on to
        GameObject[] humans = GameObject.FindGameObjectsWithTag("human");
        
        //setting to beyond the range of our tower to ensure that the tower doesn't lock on if no enemies are found
        float shortestDistance = towerRange * 2;
        //defaulting the nearest enemy to the tower as null before one is located
        GameObject nearestHuman = null;

         foreach (GameObject human in humans)
        {
            float distance = Vector3.Distance(transform.position, human.transform.position);
            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestHuman = human;
            }

            if(nearestHuman != null && shortestDistance <= towerRange)
            {
                target = nearestHuman.transform;
            }

            else
            {
                target = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //vector that is pointing in the direction of the enemy
        if(target != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(this.gameObject.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            this.gameObject.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if(fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
     
    }

    void Shoot()
    {
        //spawns the bullet in once this function is called
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletMovement bullet = bulletGO.GetComponent<bulletMovement>();

        //if the bullet exists, call the seek method
        if(bullet != null)
        {
            bullet.chaseTarget(target, lockOn);
        }

    }

    //allows us to track the range of the tower we have selected
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }
}
