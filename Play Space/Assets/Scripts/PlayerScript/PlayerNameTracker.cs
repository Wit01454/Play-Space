using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;
using System;
using FishNet.Object.Synchronizing;

public class PlayerNameTracker : NetworkBehaviour
{
    public static event Action<NetworkConnection, string> OnNameChange;

    [SyncObject]
    private readonly SyncDictionary<NetworkConnection, string> _playerName = new SyncDictionary<NetworkConnection, string>();

    private static PlayerNameTracker _instance;

    private void Awake()
    {
        _instance = this;
        _playerName.OnChange += _playerName_OnChange;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        base.NetworkManager.ServerManager.OnRemoteConnectionState += ServerManager_OnRemotrConnectionState;
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        base.NetworkManager.ServerManager.OnRemoteConnectionState -= ServerManager_OnRemotrConnectionState;
    }


    private void ServerManager_OnRemotrConnectionState(NetworkConnection arg1,FishNet.Transporting.RemoteConnectionStateArgs arg2)
    {
        if (arg2.ConnectionState != FishNet.Transporting.RemoteConnectionState.Started)
            _playerName.Remove(arg1);
    }

    private void _playerName_OnChange(SyncDictionaryOperation op,NetworkConnection Key,string value,bool asServer)
    {
        if (op == SyncDictionaryOperation.Add || op == SyncDictionaryOperation.Set)
            OnNameChange?.Invoke(Key, value);
    }

        
    public static string GatPlayerName(NetworkConnection conn)
    {
        if (_instance._playerName.TryGetValue(conn, out string result))
            return result;
        else
            return string.Empty;
    }


    [Client]
    public static void SetName(string name)
    {
        _instance.SeverSetName(name);
    }

    ///<param name="name"></param>
    /// <param name="sender"></param>
    [ServerRpc(RequireOwnership = false)]

    private void SeverSetName(string name,NetworkConnection sender = null)
    {
        _playerName[sender] = name;
    }
} 
