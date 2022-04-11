using UnityEngine;

public class EnemySystems : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    public int health;
    public int moneyValue;
    private float halfSpeed;

    //boolean to determine if the enemy is a dancing boss or not
    public bool canDance;
    private float regenTime = 0;
    public int regenAmount;
    public int regenCooldown;

    private AudioSource EnemyDeathOne;
    private AudioSource EnemyHitOne;
    

    void Start()
    {
        target = Waypoints.waypoints[0];

        //we will use the half speed variable so that the enemy won't continuously get slower if they keep getting hit by the slowdown bullets
        halfSpeed = speed / 2;

        EnemyDeathOne = GameObject.FindGameObjectWithTag("DeathNoise").GetComponent<AudioSource>();
        EnemyHitOne = GameObject.FindGameObjectWithTag("EnemyHitOne").GetComponent<AudioSource>();
        
    }

    void Update()
    {

        
        //if statement to determine if the enemy is dead or not
        if (health <= 0)
        {
            EnemyDeathOne.Play();
            //add money to the player's bank account
            CurrencyScript.currency = CurrencyScript.currency + moneyValue;
            
            Destroy(gameObject);

            //return so that the rest of the code does not run
            return;
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        if (canDance == true)
        {
            regenTime = regenTime + Time.deltaTime;

            //after every second regen
            if (regenTime >= regenCooldown)
            {
                health = health + regenAmount;
                regenTime = 0;
            }
        }
    }

    void GetNextWayPoint()
    {
        //following the checkpoints from the array of waypoints in the hierarchy
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            if (canDance == false)
            {
                HealthScript.health = HealthScript.health - health;
            }
            else
            {
                HealthScript.health = 0;
            }


            Destroy(gameObject);

        }

        if (wavepointIndex < Waypoints.waypoints.Length - 1)
        {
            wavepointIndex++;
            target = Waypoints.waypoints[wavepointIndex];
        }

    }

    //we will check for collisions with bullets to detemrine if their health should go away
    private void OnTriggerEnter(Collider other)
    {
        //check the tag of what is entering the object
        if (other.transform.tag == "bullet")
        {
            health = health - other.GetComponent<bulletMovement>().bulletPower;
        }

        //instance in which the bullet type slows down the enemy
        else if (other.transform.tag == "slowdownBullet")
        {
            health = health - other.GetComponent<bulletMovement>().bulletPower;

            //if the enemy hasn't already been slown down, then slow their speed down
            if (speed != halfSpeed)
            {
                speed = speed / 2;
            }

        }

        if (other.transform.tag == "explosion")
        {
            health = health - other.GetComponent<ExplosionScript>().explosionPower;
        }

        if(health > 0)
        {
            EnemyHitOne.Play();
        }
    }

   
}