using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPose : MonoBehaviour {


    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject splash;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    private GameMaster gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        //MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    /*
    void Update () {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
    */

    public void Die()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //MusicSource.Play();
        Debug.Log("Game over");
        Destroy(gameObject);

        Instantiate(splash, transform.position, Quaternion.identity);


        gameOverUI.SetActive(true);
        //Time.timeScale = 0;
    }
}
