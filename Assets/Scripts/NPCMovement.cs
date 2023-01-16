using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 1f;
    public List<Transform> listOfWaypoints;
    private int currentIndexOfWaypoint;
    public bool checkIfTableIsFree;
    void Start()
    {
        currentIndexOfWaypoint = 0;
    }
    
    void Update()
    {
        TableSearch();
    }

    void TableSearch()
    {
        if (Vector3.Distance(transform.position, listOfWaypoints[currentIndexOfWaypoint].position) < 0.001f)
        {
            currentIndexOfWaypoint++;

            if (currentIndexOfWaypoint > listOfWaypoints.Count)
            {
                currentIndexOfWaypoint = 0;
            }
        }

        var move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, listOfWaypoints[currentIndexOfWaypoint].position, move);
    }
}
