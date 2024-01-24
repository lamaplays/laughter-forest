using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followsScript : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;



    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
    }
}
