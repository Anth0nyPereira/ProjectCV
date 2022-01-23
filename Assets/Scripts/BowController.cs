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
            
            
        }

        if(Input.GetKey(fireButton) && charge < chargeMax)
        {
            
            charge += Time.deltaTime * chargeRate;
            //Debug.Log(charge.ToString());

            
            var sz = particleBase.sizeOverLifetime;
            sizeP = remap(0, chargeMax, 0, 5, charge);
            sz.size = new ParticleSystem.MinMaxCurve(sizeP, curve);
            
            
        }

        if (Input.GetKeyUp(fireButton))
        {
            //Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody; //criar um novo rigidbody para substiuir o nosso
            Instantiate(arrowPrefab, spawn.position, spawn.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * charge, ForceMode.Impulse);
           // arrow.AddForce(spawn.forward * charge, ForceMode.Impulse);
            charge = 0;
            particleBase.Clear();
            particleBase.Stop();
            
            
            
        }


    }


}
