using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBulletScript : MonoBehaviour
{
    // �������������A���^�C���Ō�����������
    // �p�[�e�B�N���͐������Ďc���c��

    // �_���[�W�v�Z
    float range = 0;
    int damege = 0;
    [HideInInspector] public float usedEnergy_clone;
    [HideInInspector] public float speed_clone;

    // �����v�Z
    Vector3 startPos;
    float distance = 0;

    // �J���[�ύX
    Color color;
    ParticleSystem ps;

    // ���\�b�h
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();

        startPos = transform.position;
    }

    void Update()
    {
        if(usedEnergy_clone <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        distance = (int)(Vector3.Distance(startPos, transform.position));
        Destroy(gameObject);
    }

    //�e�X�g�p�A���������͂ł���
    void OnDestroy()
    {
        //Debug.Log(EnergyDamege());
    }

    // �֐�

    // �_���[�W�Z�o
    public int EnergyDamege()
    {
        if ((int)(distance / 100) >= 1)
        {
            for (int _ = 0; _ <= (int)(distance / 100); _++)
            {
                DistanceDecay();
            }
        }

        damege = (int)usedEnergy_clone;

        return damege;
    }

    // ���������p�̊֐��A�����̂͊m�F�ς�
    void DistanceDecay()
    {
        usedEnergy_clone = (int)(usedEnergy_clone * 0.8f);
        //Debug.Log("�_���[�W�����I");
    }

    void FilghtDistance()
    {
        range += speed_clone / Time.fixedDeltaTime;
        Invoke("FilghtDistance", Time.fixedDeltaTime);
    }
}
