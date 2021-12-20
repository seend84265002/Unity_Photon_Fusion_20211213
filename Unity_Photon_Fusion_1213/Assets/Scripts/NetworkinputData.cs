using Fusion;
using UnityEngine;
/// <summary>
/// 連線輸入資訊
/// 保存連線玩家輸入資料
/// </summary>
public struct NetworkinputData : INetworkInput
{
    /// <summary>
    /// 坦克移動方向
    /// </summary>
    public Vector3 direction;
    /// <summary>
    /// 是否點擊左鍵
    /// </summary>
    public bool inputFire;
    
}
