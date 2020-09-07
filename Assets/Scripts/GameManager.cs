using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int heart; //체력 수
    public int Ice; //얼음 공격 수
    public int CutNum; //인트로 컷 수

    //UI
    public Image[] UIheart;
    public Image[] UIIce;
    public GameObject UIYouDied;
    public Button restartButton;
    public GameObject titleScreen;
    public Slider BossHpBar;

    public Image[] Cut;
    public GameObject Intro;

    private void Start()
    {
        CutNum = 0;
    }
    public void HealthDownEnemy() //플레이어 체력 감소
    {
        if (heart > 0) {
            UIheart[heart-1].color = new Color(0, 0, 0, 0.4f);
            heart--;
         }
    }
    void Update()
    {
        if(heart <= 0)
        {
            //죽으면 다시 시작하기 버튼 활성화
            restartButton.gameObject.SetActive(true);
            //죽으면 유다이 메시지 띄우기
            UIYouDied.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (CutNum < 4)
            {
                if (Cut[CutNum].gameObject.activeSelf == false)
                {
                    Cut[CutNum].gameObject.SetActive(true);
                    CutNum++;
                }
            }
            if (CutNum == 4)
            {
                Intro.SetActive(false);
            }
        }

    }
    //재시작하기
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 처음 신으로 돌아가기
    }

    public void GameStart()
    {
        titleScreen.gameObject.SetActive(false);
    }

    public void FilledIce()
    {
        if (UIIce[0].fillAmount != 1)
        {
            UIIce[0].fillAmount += 0.2f;
        }
        else if (UIIce[0].fillAmount == 1 && UIIce[1].fillAmount != 1)
        {
            UIIce[1].fillAmount += 0.2f;
        }
        else if (UIIce[0].fillAmount == 1 && UIIce[1].fillAmount == 1 && UIIce[2].fillAmount != 1)
        {
            UIIce[2].fillAmount += 0.2f;
        }
    }
    public void BossHealthDown()
    {
        BossHpBar.value -= 0.01f;
    }
   public void BossHealthDownIce()
    {
        BossHpBar.value -= 0.05f;
    }

}
