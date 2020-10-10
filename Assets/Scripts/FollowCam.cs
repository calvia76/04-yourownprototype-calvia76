using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FollowCam : MonoBehaviour
{

    public GameObject player;
    Transform target;
    

    private Vector3 offset;

    // Start is called before the first frame update
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(target);
    }



}
