using UnityEngine;
using Fusion;
using UnityEngine.UI;
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
    public Bullet bullet;
    [Header("�l�u�ͦ���m")]
    public Transform pointFire;
    [Header("����")]
    public Transform traTower;
    /// <summary>
    /// ��ѫǿ�J�ϰ�
    /// </summary>
    private InputField inputMessage;
    /// <summary>
    /// ��ѰT��
    /// </summary>
    private Text textAllMessage;
    /// <summary>
    /// �s�u���ⱱ�
    /// </summary>
    private NetworkCharacterController ncc;
    #endregion

    #region �ݩ�
    /// <summary>
    /// �}�j���j�p�ɾ�
    /// </summary>
    public TickTimer interval { get; set; }
    #endregion

    #region �ƥ�
    private void Awake()
    {
        ncc = GetComponent<NetworkCharacterController>();
        textAllMessage = GameObject.Find("��ѰT��").GetComponent<Text>();
        inputMessage = GameObject.Find("��ѿ�J�ϰ�").GetComponent<InputField>();
        inputMessage.onEndEdit.AddListener((string message) => { InputMessage(message); } );
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�p�G �I�� ���� �W�� �]�t �l�u �N �R��
        if (collision.gameObject.name.Contains("�l�u")) Destroy(gameObject);
    }
    #endregion
    #region ��k
    /// <summary>
    /// ��J�T���P�P�B�T��
    /// </summary>
    /// <param name="message"></param>
    private void InputMessage(string message)
    {
        if (Object.HasInputAuthority)
        {
            RPC_SendMessage(message);
        }
    }
    [Rpc(RpcSources.InputAuthority,RpcTargets.All)]
    private void RPC_SendMessage(string message ,RpcInfo info = default)
    {
        textAllMessage.text += (message + "\n");
    }
    /// <summary>
    /// Fusion �T�w��s�ƥ� ������ Unity Fixed Updata
    /// </summary>
    public override void FixedUpdateNetwork()
    {
        Move();
        Fire();    
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
            // ���o�ƹ��y�� �ñNY���w�P����@�˪������קK����n��
            Vector3 positionMouse = dataInput.positionMouse;
            positionMouse.y = traTower.position.y;
            // ���𪺫e��b�V= �ƹ� - �Z�J(�V�q)
            traTower.forward = positionMouse - transform.position;
        }
    }
    /// <summary>
    /// �}�j
    /// </summary>
    private void Fire()
    {
        if(GetInput(out NetworkinputData dataInput))            //�p�G ���a��J���
        {
            if (interval.ExpiredOrNotRunning(Runner))           //�p�G �}�j���j�p�ɾ�    �L���Ϊ̨S���b����
            {
                if (dataInput.inputFire)                        //�p�G ��J��ƬO�}�j����
                {
                    interval = TickTimer.CreateFromSeconds(Runner, intervalFire);       //�إ߭p�ɾ�

                    Runner.Spawn(                                                   //�s�u.�ͦ�(�s�u����A�y�СA���סA��J�v���A�ΦW�禡(���澹.�ͦ�����) => {})
                         bullet,
                         pointFire.position,
                         pointFire.rotation,
                         Object.InputAuthority,
                         (runner, objectSpawn) =>
                         {
                            objectSpawn.GetComponent<Bullet>().Init();
                         });                   
                }
            }
        }
    }
    #endregion
}
