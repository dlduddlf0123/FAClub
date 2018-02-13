using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    //모든 UI관련 동작을 관리한다
    //버튼, 게이지 등

    public Image hpGauge;
    public Image spGauge;

    GameManager gameMgr;

	void Awake () {
        gameMgr = GameManager.Inst;
        
        hpGauge.fillAmount = gameMgr.player.maxHp;
        spGauge.fillAmount = gameMgr.player.maxSp;

    }

    public void UseSp()
    {
        if (spGauge.fillAmount > 1.0f)
        {
            spGauge.fillAmount -= 1.0f;
        }
    }
    public void HPDown(float num)
    {
        Image img = hpGauge;
        if (img.fillAmount > num)
        {
            img.fillAmount -= num;
        }
    }
}
