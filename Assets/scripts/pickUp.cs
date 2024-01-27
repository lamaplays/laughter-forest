using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public GameObject key;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("player"))
        {  Destroy(key); }
    }
}
