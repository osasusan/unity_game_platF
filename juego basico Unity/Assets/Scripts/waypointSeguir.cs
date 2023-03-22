using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointSeguir : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIn = 0;

    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
  

    // Update is called once per frame
   public void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIn].transform.position) < .1f)
        {
            currentWaypointIn++;
            if (currentWaypointIn >= waypoints.Length)
            {
                currentWaypointIn = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIn].transform.position, speed * Time.deltaTime);
    }
}
