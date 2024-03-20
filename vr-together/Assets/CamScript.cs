using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : Unity.Netcode.NetworkBehaviour
{
    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner)
        {
            cam.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
