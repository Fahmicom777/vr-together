using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class CamScript : NetworkBehaviour
{

    CinemachineVirtualCamera cam;
    [SerializeField] private CinemachineVirtualCamera virtCam;
    [SerializeField] private AudioListener audioListener;
    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner) return;
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponent<CinemachineVirtualCamera>();
        if (!cam.enabled)
        {
            cam.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            audioListener.enabled = true;
            virtCam.Priority = 10;
        }
        else
        {
            virtCam.Priority = 0;
            enabled = false;
        }
    }
}

