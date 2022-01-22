using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectileController : MonoBehaviour
{
    public int i = 0;
    public int score;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.CompareTag("Target")){

        //    Destroy(other.gameObject);
        //    Debug.Log(i);
        //}
    }
}