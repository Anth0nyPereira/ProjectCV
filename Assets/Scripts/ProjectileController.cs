using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target")){

            Destroy(other.gameObject);
        }
    }
}