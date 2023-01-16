using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
// using Random = System.Random;
using Random = UnityEngine.Random;

public class NPCMovement : MonoBehaviour
{
    // private BoxCollider2D bc;
    public float speed = 1f;
    public List<Transform> listOfWaypoints;
    private SpriteRenderer sr;
    public List<Sprite> listOfSprites;
    // [SerializeField] private Transform Chair;
    private int currentIndexOfWaypoint;
    private int currentIndexOfSprites;
    private bool isSitting;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentIndexOfWaypoint = 0;
        currentIndexOfSprites = 0;
        isSitting = false;
    }
    
    void Update()
    {
        TableSearch();
    }

    void TableSearch()
    {
        // int index = new Random().Next(listOfSprites.Count);
        // print(index);
        // gameObject.transform.
        
        if (sr)
        {
            sr.sprite = listOfSprites[Random.Range(0, listOfSprites.Count)];
        }
        
        if (isSitting == true) return;
        
        if (Vector3.Distance(transform.position, listOfWaypoints[currentIndexOfWaypoint].position) < 0.001f)
        {
            currentIndexOfWaypoint++;
        
            if (currentIndexOfWaypoint > listOfWaypoints.Count)
            {
                currentIndexOfWaypoint = 0;
            }
        }

        if (transform.position != listOfWaypoints[2].position)
        {
            var move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, listOfWaypoints[currentIndexOfWaypoint].position, move);
        }
        else
        {
            isSitting = true;
        }
        
    }
    
}
