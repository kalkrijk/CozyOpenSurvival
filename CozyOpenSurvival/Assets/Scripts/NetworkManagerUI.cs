using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button clientBtn;

    private void Awake()
    {
        serverBtn.onClick.AddListener(() =>
        {
            Debug.Log("Started Server");
            NetworkManager.Singleton.StartServer();
        });
        hostBtn.onClick.AddListener(() =>
        {
            Debug.Log("Started Host");
            NetworkManager.Singleton.StartHost();
        });
        clientBtn.onClick.AddListener(() =>
        {
            Debug.Log("Started Client");
            NetworkManager.Singleton.StartClient();
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            NetworkManager.Singleton.StartHost();
        }else if (Input.GetKeyDown(KeyCode.C))
        {
            NetworkManager.Singleton.StartClient();
        }
    }

}
