using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public GameObject Rotator_1;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
            
            Camera.main.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
            //Camera.main.transform.position += Camera.main.transform.right;
                
    }
    private void OnTriggerExit(Collider other)
    {
        print("yoot");
    }
}
