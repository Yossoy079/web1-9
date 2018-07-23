using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;
    private const float masuSize = 1.0f; //ステージの一辺のサイズは1らしい
    private const float min = -1.0f; //ステージは0,0に存在する3*3の正方形らしい
    private const float max = 1.0f;

	// Use this for initialization
	void Start () {
        this.director = GameObject.Find("GameDirector");
        this.aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 thisPos = transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(thisPos.z != max)
                transform.position = new Vector3(thisPos.x, 0, thisPos.z + masuSize);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (thisPos.z != min)
                transform.position = new Vector3(thisPos.x, 0, thisPos.z - masuSize);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (thisPos.x != min)
                transform.position = new Vector3(thisPos.x - masuSize, 0, thisPos.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (thisPos.x != max)
                transform.position = new Vector3(thisPos.x + masuSize, 0, thisPos.z);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<ParticleSystem>().Play();
        if (other.gameObject.tag == "Apple")
        {
            this.director.GetComponent<GameDirector>().GetApple();
            this.aud.PlayOneShot(this.appleSE);

        }
        else
        {
            this.director.GetComponent<GameDirector>().GetBomb();
            this.aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }
}
