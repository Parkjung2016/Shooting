using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARC : MonoBehaviour
{

    public void Effect()
    {
        gameObject.SetActive(true);
        EnemyBase[] Enemies = FindObjectsOfType<EnemyBase>();
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].ApplyDamage(10000);
        }
        GameManager._instance._pC.HP += 40;
        GameManager._instance._pC.HpUpSFX();
    }

}
