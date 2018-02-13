using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour {

    public GameObject cloud1; //맨 뒤
    public GameObject cloud2; //중간
    public GameObject cloud3; //맨 앞

    public GameObject grass;

    public GameObject castle;

    public GameObject title;

    float timer = 0.0f;
    Vector3 startpos;
    float speed = 1f; //얼마나 빨리 움직이게 하고 싶은지에 따라서 조정
    float height = 0.3f; //얼마나 크게 이동하고 싶은지에 따라서 조정

    void Awake()
    {
        startpos = title.transform.position;
        StartCoroutine(BGLoop());

	}
    //움직임들
    IEnumerator BGLoop()
    {
        while (true)
        {
            //구름 움직임
            cloud1.transform.Translate(-0.001f, 0, 0);
            cloud2.transform.Translate(-0.003f, 0, 0);
            cloud3.transform.Translate(-0.007f, 0, 0);
            grass.transform.Translate(-0.01f, 0, 0);

            LoopReset(cloud1);
            LoopReset(cloud2);
            LoopReset(cloud3);
            LoopReset(grass);

            //타이틀 위아래로
            timer += Time.deltaTime * speed;
            title.transform.position = startpos + new Vector3(0, Mathf.Sin(timer) * height, 0);

            yield return null;
        }
    }

    public void LoopReset(GameObject go)
    {
        if (go.transform.position.x < -20)
        {
            go.transform.position = new Vector2(20, go.transform.position.y);
        }
    }
}
