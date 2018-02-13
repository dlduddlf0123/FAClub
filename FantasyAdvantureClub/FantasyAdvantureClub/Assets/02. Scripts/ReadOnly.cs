using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FAClub.ReadOnly
{
    public static class Defines
    {
        public const string RESOURCE_PREFAB_PLAYER = "Prefabs/Player";

        public const string SOUND_BGM_STAGE1 = "Sounds/BGM/AStarryNight";
        public const string SOUND_BGM_STAGE2 = "Sounds/BGM/happyColorfulDay";
        public const string SOUND_BGM_STAGE3 = "Sounds/BGM/Kiss";

        public const string SOUND_SFX_JUMP = "Sounds/SFX/Jump";
        public const string SOUND_SFX_ATTACK1 = "Sounds/SFX/Attack1";
        public const string SOUND_SFX_ATTACK2 = "Sounds/SFX/Attack2";
        public const string SOUND_SFX_BOXCRUSH = "Sounds/SFX/Box_Crush";
        public const string SOUND_SFX_CLICK = "Sounds/SFX/ButtonClick";
        public const string SOUND_SFX_ENEMYHIT = "Sounds/SFX/EnemyHit";
        public const string SOUND_SFX_PLAYERHIT = "Sounds/SFX/PlayerHit";
        public const string SOUND_SFX_FALL = "Sounds/SFX/Falling";
        public const string SOUND_SFX_GETCOIN = "Sounds/SFX/get";
        public const string SOUND_SFX_GETHEART = "Sounds/SFX/heartGet";
        public const string SOUND_SFX_SKILL = "Sounds/SFX/Impact_Boom_Distorted";

    }

    public enum STAT
    {
        IDLE = 0,
        ATTACK = 1,
        ATTACK2 = 2,
        ATTACK3 = 3,
        RUN = 4,
        JUMP = 5,
        HIT = 6,
        DIE = 7,
        INVINCIBLE,
    }

    public enum GAME
    {
        MENU = 0,
        PLAY = 1,
        GAMEOVER = 2,
    }
    
}
