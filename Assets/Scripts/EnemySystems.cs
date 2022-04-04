using UnityEngine;

public class EnemySystems : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    public int health;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
        //if statement to determine if the enemy is dead or not
        if(health <= 0)
        {
            Destroy(gameObject);

            //return so that the rest of the code does not run
            return;
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {

        if(wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
        }

        if(wavepointIndex < Waypoints.waypoints.Length - 1)
        {
            wavepointIndex++;
            target = Waypoints.waypoints[wavepointIndex];
        }
        
    }

    //we will check for collisions with bullets to detemrine if their health should go away
    private void OnTriggerEnter(Collider other)
    {
        //check the tag of what is entering the object
        if(other.transform.tag == "bullet")
        {
            health = health - other.GetComponent<bulletMovement>().bulletPower;
        }
    }
}
