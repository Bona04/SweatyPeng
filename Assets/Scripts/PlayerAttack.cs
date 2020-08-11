using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attack;
    public Transform pos;
    public float cooltime;
    private float curtime;
    Animator anime;


    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z)) //기본공격
            {
                anime.SetTrigger("Attack");
                Instantiate(attack, pos.position, transform.rotation);

                curtime = cooltime;
            }
        }
        curtime -= Time.deltaTime;

    }
}
