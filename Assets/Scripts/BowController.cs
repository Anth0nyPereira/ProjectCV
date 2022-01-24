using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.Mathematics.math;

public class BowController : MonoBehaviour
{
    
    float charge;
    public float chargeMax;
    public float chargeRate;

    public KeyCode fireButton;

    public TextMeshProUGUI _text;
    public Transform spawn;
    public Rigidbody arrowObj;
    public GameObject arrowPrefab;

    //teste
    //ParticleSystem particleBase = GetComponentInChildren<ParticleSystem>();
    public ParticleSystem particleBase;
    private AnimationCurve curve = new AnimationCurve();
    float sizeP;

    //light size with power shot
    public Light pLight;
    public Light lantern;
    public KeyCode rightButton;

    private void Start()
    {
        curve.AddKey(0.0f, 0.3f);
        curve.AddKey(1.0f, 0.3f);
      

    }

    private void Update()
    {


        if(Input.GetKeyDown(fireButton))
        {
            particleBase.Play();
            pLight.enabled = true;
            
        }

        if(Input.GetKey(fireButton) && charge < chargeMax)
        {
            
            charge += Time.deltaTime * chargeRate;
            //Debug.Log(charge.ToString());

            
            var sz = particleBase.sizeOverLifetime;
            sizeP = remap(0, chargeMax, 0, 3, charge);
            sz.size = new ParticleSystem.MinMaxCurve(sizeP, curve);
            pLight.intensity = sizeP;
            
            
        }

        if (Input.GetKeyUp(fireButton))
        {
            //Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody; //criar um novo rigidbody para substiuir o nosso
            Instantiate(arrowPrefab, spawn.position, spawn.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * charge, ForceMode.Impulse);
           // arrow.AddForce(spawn.forward * charge, ForceMode.Impulse);
            charge = 0;
            particleBase.Clear();
            particleBase.Stop();
            pLight.enabled = false;

            
            
            
        }

        if (Input.GetKeyDown(rightButton))
        {
            lantern.enabled = true;
        }

         if (Input.GetKeyUp(rightButton))
        {
            lantern.enabled = false;
        }



    }


}
