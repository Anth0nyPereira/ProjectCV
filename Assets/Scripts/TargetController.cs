using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject explosion; // drag your explosion prefab here
    float duration = 3.0f;
    float originalRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Arrow")){
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
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
