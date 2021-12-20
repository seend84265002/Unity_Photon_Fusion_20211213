using UnityEngine;
using UnityEngine.UI;
using Fusion;               //引用Fusion
using Fusion.Sockets;
using System.Collections.Generic;
using System;

//INetworkRunnerCallbacks 連線執行器回呼介面，Runner 執行器處理行為後會回呼此介面的方法
/// <summary>
/// 連線基底生成器
/// </summary>
public class BasicSpawner : MonoBehaviour,INetworkRunnerCallbacks
{

    #region 欄位
    [Header("創建與加入房間欄位")]
    public InputField inputFieldCreatRoom;
    public InputField inputFieldJoinRoom;
    [Header("玩家控制元件")]
    public GameObject goPlayer;

    /// <summary>
    /// 玩家輸入房間名稱
    /// </summary>
    private string roomNameInput;
    #endregion
    #region 方法
    /// <summary>
    /// 按鈕點擊呼叫創建房間
    /// </summary>
    public void BtnCreateRoom()
    {
        roomNameInput = inputFieldCreatRoom.text;
        Debug.Log("創建房間:" + roomNameInput);
    }
    public void BtnJoinRoom()
    {
        roomNameInput = inputFieldJoinRoom.text;
        Debug.Log("加入房間:"+roomNameInput);

    }
    #endregion

    #region Fusion 回呼函式區域
    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }
    #endregion

}

