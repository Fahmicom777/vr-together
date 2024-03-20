using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Relay;
using UnityEngine;
using UnityEngine.UI;

public class NetworkMangerUI : NetworkBehaviour
{

    [SerializeField] private Button hostButton;
    [SerializeField] private TMP_InputField joinCodeInput;
    [SerializeField] private Button joinButton;
    public GameObject relayManager;

    private void Awake()
    {
        hostButton.onClick.AddListener(async () =>
        {
            string joinCode = await relayManager.GetComponent<RelayScript>().CreateRelay();
            if (joinCode == null) return;
            hostButton.gameObject.SetActive(false);
            joinCodeInput.gameObject.SetActive(false);
            joinButton.gameObject.SetActive(false);
        });

        joinButton.onClick.AddListener(async () =>
        {
            string joinCode = joinCodeInput.text;
            if (joinCode == "" || joinCode == null)
            {
                return;
            }
            bool success = await relayManager.GetComponent<RelayScript>().JoinRelay(joinCode);
            joinCodeInput.text = "";
            if (success)
            {
                hostButton.gameObject.SetActive(false);
                joinCodeInput.gameObject.SetActive(false);
                joinButton.gameObject.SetActive(false);
            }
        });
    }
}
