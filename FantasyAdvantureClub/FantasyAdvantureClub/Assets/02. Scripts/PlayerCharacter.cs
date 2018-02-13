using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FAClub.ReadOnly;

public class PlayerCharacter : MonoBehaviour {

    GameManager gameMgr;

    BoxCollider2D _playerColl;
    Rigidbody2D _playerRb;
    Animator _playerAnim;
    Renderer _playerRender;

    public float speed;
    public float minSpeed;
    public float maxSpeed;
    public float jumpForce;
    public Vector2 backwardForce;

    public int maxHp;
    public int hp;

    public int maxSp;
    public int sp;

    public int attack;

    public bool isJump;
    public bool isDbJump;
    public bool isGround;

    STAT pStat;

    void Awake()
    {
        gameMgr = GameManager.Inst;

        //player 요소 가져오기
        _playerColl = GetComponent<BoxCollider2D>();
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        _playerRender = GetComponent<Renderer>();

        //변수 초기화
        maxHp = hp = 4;
        maxSp = sp = 4;

        minSpeed = 5f;
        maxSpeed = 10f;

        jumpForce = 13f;
        backwardForce = new Vector2(10, 10);

        attack = 0;

        pStat = STAT.IDLE;

        Time.timeScale = 1f;

        StartCoroutine(State());
    }

    IEnumerator State()
    {
        while (gameMgr.sGame != GAME.GAMEOVER)
        {
            switch (pStat)
            {
                case STAT.IDLE:
                    break;
                case STAT.ATTACK:
                    break;
                case STAT.ATTACK2:
                    break;
                case STAT.ATTACK3:
                    break;
                case STAT.RUN:
                    break;
                case STAT.JUMP:
                    JumpControl();
                    break;
                case STAT.HIT:
                    //플레이어 피격시
                    PlayerHit();
                    break;
                case STAT.DIE:
                    break;
                default:
                    break;
            }

            if (this.transform.position.y < -4.0f)
            {
                pStat = STAT.DIE;
            }
            yield return null;

        }
    }

    //충돌체크
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            pStat = STAT.IDLE;
            isJump = false;
            isDbJump = false;
            doRun();
        }

    }
    
    /*//키 입력 받아 좌우 이동(테스트용)
    void Moves()
    {
        _playerAnim.SetFloat("height", _playerRb.velocity.y);
        _playerAnim.SetBool("isGround", true);

        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (speed < maxSpeed)
        {
            speed += 2 * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
    }*/

    //점프 동작
    public void Jump()
    {
        isGround = false;
        Vector3 tmpVelocity = _playerRb.velocity;
        tmpVelocity.y = jumpForce;
        _playerRb.velocity = tmpVelocity;
        gameMgr.soundMgr.PlaySfx(Defines.SOUND_SFX_JUMP);
    }
    
    //점프 제어문
    public void JumpControl()
    {
        //바닥과 닿아있고 점프가 아닐 경우
        if (isGround && !isJump)
        {
            isJump = true;
            Jump();
            doJump();
            isGround = false;
        }
        //점프상태이고 더블점프 상태가 아닐 경우
        else if (isJump && !isDbJump)
        {
            isDbJump = true;
            Jump();
            doDoubleJump();
            isJump = false;
        }
    }

    public void PlayerHit()
    {
        gameMgr.uiMgr.HPDown(1.0f);
        _playerAnim.SetTrigger("isHit");
        gameMgr.soundMgr.PlaySfx(Defines.SOUND_SFX_PLAYERHIT);
        _playerRb.velocity = new Vector2(
            transform.right.x * backwardForce.x,
            transform.up.y * backwardForce.y);
        speed = minSpeed;
    }
    //==========애니메이팅 함수=============
    //달리기
    public void doRun()
    {

    }
    //점프
    public void doJump()
    {

    }
    //더블점프
    public void doDoubleJump()
    {


    }
    //공격
    public void doAttack1()
    {
        gameMgr.uiMgr.UseSp();
    }
    
    //===================스킬=======================
    public void FastRun()
    {
        //속도
        speed = 15;
        //코루틴 호출
        StartCoroutine("FastSkill");

    }


    //=================게임오버======================
    public void Dead()
    {
        pStat = STAT.DIE;

    }
}
