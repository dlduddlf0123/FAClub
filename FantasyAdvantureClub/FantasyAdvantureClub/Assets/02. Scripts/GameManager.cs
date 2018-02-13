using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using FAClub.ReadOnly;

public class GameManager : MonoSingleton<GameManager>
{
    //게임에서 필요한 각종 기능 설정
    //singleton화
    //모든 스크립트를 가지고 있다
    public PlayerCharacter player;
    public EnemyCharacter enemy;

    public UIManager uiMgr;
    public SoundManager soundMgr;

    public GAME sGame;

    private void Awake()
    {
        sGame = GAME.MENU;

    }

    private void SetPlayer()
    {
        player = (PlayerCharacter)Instantiate(Resources.Load(Defines.RESOURCE_PREFAB_PLAYER));

        player.gameObject.SetActive(false);
    }
}
