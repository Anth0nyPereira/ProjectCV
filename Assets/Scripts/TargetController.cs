using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private ScoreController scoreController;

    public GameObject target;
    public Transform[] targetPos;
    public GameObject[] spawntargets;
    private int x = 0;
    private int randomSpawnSpot;
    private Vector3 spawnPoint;
    private Collider[] hitColliders;
    private int score = 0;

    bool hasTarget;


    public GameObject explosion; // drag your explosion prefab here
    float duration = 3.0f;
    float originalRange;

    private void Awake()
    {
        scoreController = GameObject.FindObjectOfType<ScoreController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        randomSpawnSpot = Random.Range(0, targetPos.Length);
        spawnPoint = targetPos[randomSpawnSpot].position; 
        hitColliders = Physics.OverlapSphere(spawnPoint, 2);//1 is purely chosen arbitrarly verificar se existe algum objeto na posi��o
    }

    // Update is called once per frame
    void Update()
    {
        if (hitColliders.Length > 0)
        {
            hasTarget = true;
        }
        else
        {
            hasTarget = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Arrow")){
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
            score += 1;
            scoreController.UpdateScore(score);
           // for(int i = 0; i<targetPos.Length; i++)
            //{

            if (!hasTarget)
            {
                GameObject targetConed = Instantiate(target, targetPos[randomSpawnSpot].position, Quaternion.Euler(-90, -90, 0));
                targetConed.name = "TargetSpawn";
            }
            //}

            Destroy(expl, 1); // delete the explosion after 1 seconds

            /*GameObject lightGameObject = new GameObject("The Light");
            // Add the light component
            Light lightComp = lightGameObject.AddComponent<Light>();
            var amplitude = Mathf.PingPong(Time.time, duration);
            amplitude = amplitude / duration * 0.5f + 0.5f;
            lightComp.range = lightComp.range * amplitude;
            // Set color and position
            lightComp.color = Color.red;
            // Set the position (or any transform property)
            lightGameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(lightGameObject, 3);*/
        }
    }
}
