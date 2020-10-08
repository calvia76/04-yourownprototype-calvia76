using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    
    public GameObject player;
    private string collidePos = "";

    public  string IsCollided
    {

        get { return collidePos; }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rotate_Right")
        {
            Camera.main.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
            //Camera.main.transform.position()
            print("collision");
            collidePos = "Right";
        }else if (other.gameObject.tag == "Rotate_Left")
        {
            Camera.main.transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
            collidePos = "Left";
        }
    }
    public void CollisionReset()
    {
         collidePos = "";
    }
}
