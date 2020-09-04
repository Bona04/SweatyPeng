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

    public GameObject BombAttack;
    public GameObject BombAim;

    private float randomXvalueCopy;

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            float randomXvalue = Random.Range(100, 114);
            randomXvalueCopy = randomXvalue;

            StartCoroutine("BombAttackMethod");
        }
    }
    IEnumerator BombAttackMethod()
    {
        InvokeBombAim();
        yield return new WaitForSeconds(2);
        InvokeBomb();
    }
    void InvokeBombAim ()
    {
        Instantiate(BombAim, new Vector3(randomXvalueCopy, -2.2f, 0.0f), BombAim.transform.rotation);
    }
    void InvokeBomb ()
    {
        Instantiate(BombAttack, new Vector3(randomXvalueCopy, 4.0f, 0.0f), BombAttack.transform.rotation);
    }
}
