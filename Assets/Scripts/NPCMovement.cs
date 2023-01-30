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
    [Range(0, 10)]
    public float speed = 3f;
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
    private Vector2 movementNPC;
    public Animator animator;

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
            // var move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, listOfWaypoints[currentIndexOfWaypoint].position, speed * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        else
        {
            isSitting = true;
            animator.SetBool("isSitting", true);
        }
        
    }

    // void TableLeaving()
    // {
    //     if (foodFinished == true)
    //     {
    //         listOfWaypoints.Reverse();
    //
    //         if (Vector3.Distance(transform.position, listOfWaypoints[currentIndexOfWaypoint].position) < 0.001f)
    //         {
    //             currentIndexOfWaypoint++;
    //         }
    //         
    //         
    //         var move = speed * Time.deltaTime;
    //         transform.position = Vector3.MoveTowards(transform.position, listOfWaypoints[currentIndexOfWaypoint].position, move);
    //     }
    // }

    void TableLeaving2()
    {
        if (foodFinished == false) return;
        
        if (foodFinished == true)
        {
            if (isStillInBuilding == false) return;

            if (isStillInBuilding == true)
            {
                if (Vector3.Distance(transform.position, listOfWaypointsBackwards[currentIndexOfWaypointsBackwards].position) < 0.001f)
                {
                    currentIndexOfWaypointsBackwards++;
                    
                    // if (currentIndexOfWaypoint > listOfWaypoints.Count )
                    // {
                    //     currentIndexOfWaypoint = 0;
                    // }
                }
                
                if (currentIndexOfWaypoint < listOfWaypointsBackwards.Count)
                {
                    var move = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, listOfWaypointsBackwards[currentIndexOfWaypointsBackwards].position, move);
                    animator.SetBool("isSitting", false);
                    animator.SetBool("isGoingHome", true);
                }
                else
                {
                    isStillInBuilding = false;
                    Destroy(this);
                }
            }
        }
    }
}
