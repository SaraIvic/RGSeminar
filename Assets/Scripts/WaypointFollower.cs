using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.01f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex == waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // Move object towards next waypoint
        // We use Time.deltaTime because not all devices have same frame rate and we want to speed to be same for all devices
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}