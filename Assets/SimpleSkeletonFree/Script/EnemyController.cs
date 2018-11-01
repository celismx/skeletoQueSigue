using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{


    // Speed in units per sec.
    public float speed;
    public Transform target;
    public bool isDistanceCheck = false;
    private Animator SkeletonAC;
    private float timeBetweenAttacks = 3.0f;


    void Update()
    {

        Vector3 direction = (target.position) - transform.position;
        Vector3 distanceV3 = target.position - transform.position;
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance < 5.0f)
        {
            if (!isDistanceCheck)
                Debug.Log("la distancia es menor a 3");
            SkeletonAC.SetBool("Attack1h1", true);
            isDistanceCheck = true;
            timeBetweenAttacks -= Time.deltaTime;
            if (timeBetweenAttacks <= 0.0f)
            {
                SkeletonAC.SetBool("Attack1h1", true);
            }

        }
        
        else
        { 
        Quaternion rotation = Quaternion.LookRotation(direction);
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.rotation = rotation;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

    }
}


