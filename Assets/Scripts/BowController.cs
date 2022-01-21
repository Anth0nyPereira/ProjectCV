using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    float charge;
    public float chargeMax;
    public float chargeRate;

    public KeyCode fireButton;
   
    public Transform spawn;
    public Rigidbody arrowObj;

    private void Update()
    {
        if(Input.GetKey(fireButton) && charge < chargeMax)
        {
            charge += Time.deltaTime * chargeRate;
            Debug.Log(charge.ToString());
        }

        if (Input.GetKeyUp(fireButton))
        {
            Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody; //criar um novo rigidbody para substiuir o nosso
            arrow.AddForce(spawn.forward * charge, ForceMode.Impulse);
            charge = 0;
        }
    }


}
