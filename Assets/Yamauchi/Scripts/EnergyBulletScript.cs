using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBulletScript : MonoBehaviour
{
    // 距離減衰をリアルタイムで減少させたい
    // パーティクルは生成して残像残す

    // ダメージ計算
    float range = 0;
    int damege = 0;
    [HideInInspector] public float usedEnergy_clone;
    [HideInInspector] public float speed_clone;

    // 距離計算
    Vector3 startPos;
    float distance = 0;

    // カラー変更
    Color color;
    ParticleSystem ps;

    // メソッド
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

    //テスト用、距離減衰はできた
    void OnDestroy()
    {
        //Debug.Log(EnergyDamege());
    }

    // 関数

    // ダメージ算出
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

    // 距離減衰用の関数、動くのは確認済み
    void DistanceDecay()
    {
        usedEnergy_clone = (int)(usedEnergy_clone * 0.8f);
        //Debug.Log("ダメージ減少！");
    }

    void FilghtDistance()
    {
        range += speed_clone / Time.fixedDeltaTime;
        Invoke("FilghtDistance", Time.fixedDeltaTime);
    }
}
