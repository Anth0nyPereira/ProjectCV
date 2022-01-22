using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public GameObject target;
    public Transform[] targetPos;
    public GameObject[] spawntargets;
    private int x = 0;
    private int randomSpawnSpot;
    private Vector3 spawnPoint;
    private Collider[] hitColliders; 



    // Start is called before the first frame update
    void Start()
    {
        randomSpawnSpot = Random.Range(0, targetPos.Length);
        spawnPoint = targetPos[randomSpawnSpot].position; 
        hitColliders = Physics.OverlapSphere(spawnPoint, 2);//1 is purely chosen arbitrarly verificar se existe algum objeto na posição
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Arrow")){

            Destroy(this.gameObject);
           // for(int i = 0; i<targetPos.Length; i++)
            //{
              //  if (hitColliders.Length > 0)
                //{
                    Instantiate(target, targetPos[randomSpawnSpot].position, Quaternion.Euler(-90, -90, 0));
               // }
            //}

        }
    }
}
