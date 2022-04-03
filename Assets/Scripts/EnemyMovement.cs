using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
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
}
