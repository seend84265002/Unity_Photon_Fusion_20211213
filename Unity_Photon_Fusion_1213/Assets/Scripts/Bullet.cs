using Fusion;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    #region ���
    [Header("���ʳt��"), Range(0, 100)]
    public float speed = 5;
    [Header("�s���ɶ�"), Range(0, 10)]
    public float lifeTime = 5;

    #endregion

    #region �ݩ�
    // Networked �s�u���ݩʸ��
    /// <summary>
    /// �s���p�ɾ�
    /// </summary>
    [Networked]
    private TickTimer life { get; set; }
    #endregion

    #region ��k
    /// <summary>
    /// ��l���
    /// </summary>
    public void Init()
    {
        //�s���p�ɾ� = �p�ɾ�.�q��ƫإ�(�s�u���澹.�s���ɶ�)
        life = TickTimer.CreateFromSeconds(Runner, lifeTime);
    }

    /// <summary>
    /// Network Bechaviour �����O���Ѫ��ƥ�
    /// �s�u�ΩT�w��s 50 FPS
    /// </summary>
    public override void FixedUpdateNetwork()
    {
        // Runner �s�u���澹
        // Expried() �O�_���
        // Despawn() �R��
        // Object �s�u����
        // Runner.DeltaTime �s�u���@�ժ��ɶ�
        // �p�G �p�ɾ� �L��(���s) �N�R�� ���s�u����
        // �_�h�N����
        if (life.Expired(Runner)) Runner.Despawn(Object);
        else transform.Translate(0, 0, speed * Runner.DeltaTime);
    }
    #endregion
}
