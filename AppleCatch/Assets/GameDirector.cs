using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    int point = 0;
    GameObject generator;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

	// Use this for initialization
	void Start () {
        this.generator = GameObject.Find("ItemGenerator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }
	
	// Update is called once per frame
	void Update () {
        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 5) //最後の5秒はボーナス時間
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(this.time * 0.1f, this.time * 0.02f - 0.15f, 0);
        }
        else if (5 <= this.time && this.time < 10) //頻度と速度を上げる
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 3);
        }
        else if (10 <= this.time && this.time < 20) //頻度と速度を上げる
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        }
        else if (20 <= this.time && this.time < 25) //爆弾を落とし始める、頻度も上げる
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.9f, -0.03f, 3);
        }
        else if (25 <= this.time && this.time < 30) //最初の5秒は爆弾を落とさない
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 0);
        }


        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
	}
}
