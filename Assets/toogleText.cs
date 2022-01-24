using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class toogleText : MonoBehaviour
{

    public TextMeshProUGUI instructions;
    public KeyCode keysds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(keysds))
        {
            if(instructions.enabled == true) {
                instructions.enabled= false;
            } else {
                instructions.enabled= true;
            }
        }
        
    }
}
