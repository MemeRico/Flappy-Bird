using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    public static gameManager instance;
    // Use this for initialization
    private const string high_score = "High score";
	void Start () {
		
	}
    void _firstTime()
    {
        if (!PlayerPrefs.HasKey("_firstTime"))
        {
            PlayerPrefs.SetInt(high_score, 0);
            PlayerPrefs.SetInt("_firstTime", 0);
        }
    }
    void Awake()
    {
        _makeSingleInstance();
        _firstTime();
    }
    void _makeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void _setHighScore(int score)
    {
        PlayerPrefs.SetInt(high_score, score);
    }
    public int _getHighScore()
    {
        return PlayerPrefs.GetInt(high_score);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
