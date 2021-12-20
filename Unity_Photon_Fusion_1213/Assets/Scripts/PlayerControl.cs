using UnityEngine;
using Fusion;
/// <summary>
/// �Z�J���a���
/// �e�ᥪ�k����
/// �����P�o�g�l�u
/// </summary>
public class PlayerControl : NetworkBehaviour
{
    #region ���
    [Header("���ʳt��"), Range(0,1000)]
    public float speed = 1000f;
    [Header("�o�g�l�u���j"), Range(0, 1.5f)]
    public float intervalFire = 0.35f;
    [Header("�l�u����")]
    public GameObject bullet;

    /// <summary>
    /// �s�u���ⱱ�
    /// </summary>
    private NetworkCharacterController ncc;
    #endregion

    #region �ƥ�
    private void Awake()
    {
        ncc = GetComponent<NetworkCharacterController>();
    }
    #endregion
    #region ��k
    /// <summary>
    /// Fusion �T�w��s�ƥ� ������ Unity Fixed Updata
    /// </summary>
    public override void FixedUpdateNetwork()
    {
        Move();
    }

    
    private void Move()
    {
        //�p�G ����J���
        if (GetInput(out NetworkinputData dataInput) == Input.GetKeyDown(KeyCode.Space))
        {
            ncc.Jump();
        }
        else
        {
            //�s�u���ⱱ�.����(�t��*��V*�s�u�@���ɶ�)
            ncc.Move(speed * dataInput.direction * Runner.DeltaTime);
        }
    }

    #endregion
}
