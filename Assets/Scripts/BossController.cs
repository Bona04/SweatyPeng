using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //Animator anime;
    public float cooltime;
    private float curtime;
    public GameObject BossNormalAttack;
    public Transform BossAttackPos;

    void Start()
    {
        //anime = GetComponent<Animator>();
    }

    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q)) //기본공격
            {
                //anime.SetTrigger("NormalAttack");
                Instantiate(BossNormalAttack, BossAttackPos.position, transform.rotation);
                curtime = cooltime;
            }
        }
        curtime -= Time.deltaTime;
    }
}
