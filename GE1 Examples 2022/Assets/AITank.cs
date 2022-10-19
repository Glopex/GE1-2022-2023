using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;
    [SerializeField] public GameObject obj;
    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            float variable = (Mathf.PI * 2.0f) / numWaypoints;
            for (int i = 0; i < numWaypoints; i++)
            {
                float angle = variable * i;
                Vector3 position = new Vector3(Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle) * radius);
                position = transform.TransformPoint(position);
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(position, 1);
            }


            // Task 1
            // Put code here to draw the gizmos
            // Use sin and cos to calculate the positions of the waypoints 
            // You can draw gizmos using
            // Gizmos.color = Color.green;
            // Gizmos.DrawWireSphere(pos, 1);
        }
    }

    // Use this for initialization
    void Awake() {
        float x = (Mathf.PI * 2.0f) / numWaypoints;
        for (int i = 0; i < numWaypoints; i++)
        {
            float angle = x * i;
            Vector3 pos = new Vector3(Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos);
        }
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        Vector3 nextpos = waypoints[current] - pos;
        float distance = nextpos.magnitude;
        if (distance < 1)
        {
            current = (current + 1) % waypoints.Count;
        }
        Vector3 direction = nextpos / distance;
        transform.position = Vector3.Lerp(transform.position, waypoints[current], Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextpos, Vector3.up), 180 * Time.deltaTime);


        Vector3 toPlayer = player.position - transform.position;
        float dot = Vector3.Dot(transform.forward, toPlayer.normalized);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        if (angle < 45)
        {
            Debug.Log("can see player");
        }

        if (dot > 0)
        {
            Debug.Log("in front");
        }
        else
        {
            Debug.Log("in the back");
        }

        float angle1 = Vector3.Angle(toPlayer, transform.forward);
    }
    // Task 3
    // Put code here to move the tank towards the next waypoint
    // When the tank reaches a waypoint you should advance to the next one


    // Task 4
    // Put code here to check if the player is in front of or behine the tank
    // Task 5
    // Put code here to calculate if the player is inside the field of view and in range
    // You can print stuff to the screen using:

    
}
