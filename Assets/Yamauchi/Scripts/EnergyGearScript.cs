using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EnergyGearScript : MonoBehaviour
{
    [SerializeField,Header("�G�l���M�[�e��Prefab���A�^�b�`���Ă�������")] GameObject energyBullet;
    [Header("�G�l���M�[�v�[�����t����Object���A�^�b�`���Ă�������")] public EnergyScript energyPool;
    [Header("��肭���˂ł��Ȃ��Ȃ��Ǝv�����璲�����Ă�������")] public float instantiatePos = 1.1f;
    CoreScript core;

    int usedMax = 50;
    public float speed = 100.0f;

    // ���\�b�h
    void Start()
    {
        core = transform.parent.GetComponent<CoreScript>();
        core.AddWeight(usedMax);
    }

    // public�֐�
    public void ShotEnergy(int usedEnergy,GameObject target)
    {
        // �_���[�W�v�Z�A���Z��Bullet�̕��ōs��
        // �l��n����AddForce�������邾��

        // �����v�Z���ăG�l���M�[�g�p�ʂ��Œ���ɗ}������
        float two_distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

        // �N���[���쐬�Ɛݒ�AComponent�̎擾
        GameObject clone = EnergyBullet_clone();

        Rigidbody rb_clone = clone.GetComponent<Rigidbody>();
        EnergyBulletScript bulletSc = clone.GetComponent<EnergyBulletScript>();
        bulletSc.usedEnergy_clone = usedEnergy;
        bulletSc.speed_clone = speed;
        clone.transform.parent = gameObject.transform;

        // ��������
        Shot(rb_clone);
    }

    // privert�֐�
    GameObject EnergyBullet_clone()
    {
        GameObject energyBullet_clone =
            Instantiate(
                energyBullet,
                gameObject.transform.forward * instantiatePos, //AddForce�Ȃ̂Ő����ʒu�Ƀ��m������Ƃ��܂����˂ł��Ȃ��A�̂ł������˂��Ȃ��Ȃ��Ǝv�����璲�����Ă�
                Quaternion.identity
                );

        return energyBullet_clone;
    }

    void Shot(Rigidbody rb)
    {
        rb.AddForce(transform.forward * (speed / Time.deltaTime), ForceMode.Force);
    }
}
