using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;

public class ChatBroadcastGuide : MonoBehaviour
{
    public Transform chatHolder;
    public GameObject msgElement;
    public TMP_InputField playerUsername, playerMessage;
    public GameObject BoxChat;

    private void OnEnable()
    {
        InstanceFinder.ClientManager.RegisterBroadcast<Message>(OnMassageRecieved);
        InstanceFinder.ServerManager.RegisterBroadcast<Message>(OnClientMassageRecieved);
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.RegisterBroadcast<Message>(OnMassageRecieved);
        InstanceFinder.ServerManager.RegisterBroadcast<Message>(OnClientMassageRecieved);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessage();
        }
    }

    private void SendMessage()
    {
        Message msg = new Message()
        {
            username = playerUsername.text,
            message = playerMessage.text

        };

        playerMessage.text = "";

        if (InstanceFinder.IsServer)
            InstanceFinder.ServerManager.Broadcast(msg);
        else if (InstanceFinder.IsClient)
            InstanceFinder.ClientManager.Broadcast(msg);
    }

    private void OnMassageRecieved(Message msg)
    {
        GameObject finalMessage = Instantiate(msgElement, chatHolder);
        finalMessage.GetComponent<TextMeshProUGUI>().text = msg.username + ": " + msg.message;
    }

    private void OnClientMassageRecieved(NetworkConnection networkConnection,Message msg)
    {
        InstanceFinder.ServerManager.Broadcast(msg);
    }

    public struct Message : IBroadcast
    {
        public string username;
        public string message;
    }

    public void OpenBoxChat()
    {
        BoxChat.SetActive(true);
    }

    public void ClosBoxChat()
    {
        BoxChat.SetActive(false);
    }
}
