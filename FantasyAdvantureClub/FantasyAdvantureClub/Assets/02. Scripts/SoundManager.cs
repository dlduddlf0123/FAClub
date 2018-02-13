using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //배경음악 볼륨
    public float bgmVolume = 1.0f;
    //효과음 볼륨크기
    public float sfxVolume = 1.0f;
    //효과음 음소거
    public bool isSfxMute = false;

    //배경음악 재생함수(음악파일)
    public void PlayBgm(string _bgm)
    {
        //Bgm 객체 생성
        GameObject _bgmObj = (GameObject)Instantiate(Resources.Load(_bgm));
        //AudioSource 추가
        AudioSource _bgmSource = _bgmObj.AddComponent<AudioSource>();
        AudioClip _bgmClip = _bgmObj.GetComponent<AudioClip>();
        //음악 파일 설정
        _bgmSource.clip = _bgmClip;
        //볼륨 설정
        _bgmSource.volume = bgmVolume;
        //재생
        _bgmSource.Play();
        //반복
        _bgmSource.loop = true;
        //씬 전환시 삭제방지
        DontDestroyOnLoad(_bgmObj);
    }
    //효과음 재생함수 (재생할 위치, 재생할 소리) 
    public void PlaySfx(string _sfx)
    {
        //음소거일경우 반환
        if (isSfxMute) return;
        //Sfx 사운드 오브젝트 생성
        GameObject _soundObj = (GameObject)Instantiate(Resources.Load(_sfx));
        //오디오 소스 생성
        AudioSource _sfxSource = _soundObj.AddComponent<AudioSource>();
        AudioClip _sfxClip = _soundObj.GetComponent<AudioClip>();
        //재생할 소리 입력, 최소거리, 최대거리
        _sfxSource.clip = _sfxClip;
        _sfxSource.minDistance = 10.0f;
        _sfxSource.maxDistance = 30.0f;
        //볼륨 조절
        _sfxSource.volume = sfxVolume;
        //소리 재생
        _sfxSource.Play();
        //소리 재생 후 삭제
        Destroy(_soundObj, _sfxClip.length);
    }
    //배경음악 음소거
    public void MuteBgm()
    {
        Destroy(GameObject.Find("Bgm"));
    }

}
