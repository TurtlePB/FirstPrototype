using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCMovement : MonoBehaviour
{
    // private BoxCollider2D bc;
    public float speed = 1f;
    public List<Transform> listOfWaypoints;
    public List<Transform> listOfWaypointsBackwards;
    public SpriteRenderer sr;
    public List<Sprite> listOfSprites;
    public List<Sprite> listOfFoodWishes;
    // [SerializeField] private Transform Chair;
    private int currentIndexOfWaypoint;
    private int currentIndexOfWaypointsBackwards;
    // private int currentIndexOfSprites;
    public bool isSitting;
    public bool foodFinished;
    public bool isStillInBuilding;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentIndexOfWaypoint = 0;
        currentIndexOfWaypointsBackwards = 0;
        // currentIndexOfSprites = 0;
        isSitting = false;
        foodFinished = false;
        isStillInBuilding = false;

        if (sr)
        {
            sr.sprite = listOfSprites[Random.Range(0, listOfSprites.Count)];
        }
    }
    
    void Update()
    {
        TableSearch();
        // TableLeaving();
        TableLeaving2();
    }

    void TableSearch()
    {
        if (isSitting == true) return;
        
        if (Vector3.Distance(transform.position, listOfWaypoints[currentIndexOfWaypoint].position) < 0.001f)
        {
            currentIndexOfWaypoint++;
        
            // if (currentIndexOfWaypoint > listOfWaypoints.Count )
            // {
            //     currentIndexOfWaypoint = 0;
            // }
        }

        if (currentIndexOfWaypoint < listOfWaypoints.Count)
        {
            var move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, listOfWaypoints[currentIndexOfWaypoint].position, move);
        }
        else
        {
            isSitting = true;
        }
        
    }

    void TableLeaving()
    {
        if (foodFinished == true)
        {
            listOfWaypoints.Reverse();

            if (Vector3.Distance(transform.position, listOfWaypoints[currentIndexOfWaypoint].position) < 0.001f)
            {
                currentIndexOfWaypoint++;
            }
            
            
            var move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, listOfWaypoints[currentIndexOfWaypoint].position, move);
        }
    }

    void TableLeaving2()
    {
        if (foodFinished == true)
        {
            if (isStillInBuilding == true)
            {
                if (Vector3.Distance(transform.position, listOfWaypointsBackwards[currentIndexOfWaypointsBackwards].position) < 0.001f)
                {
                    currentIndexOfWaypointsBackwards++;
                }

                var move = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, listOfWaypointsBackwards[currentIndexOfWaypointsBackwards].position, move);

                if (currentIndexOfWaypoint > listOfWaypointsBackwards.Count)
                {
                    isStillInBuilding = false;
                }
            }
        }
    }
}