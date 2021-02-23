using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamePlayController : MonoBehaviour {

	public static gamePlayController instance;
	[SerializeField]
	private Button instructionButton;

	[SerializeField]
	public Text scoreText,endScoreText,bestscoreText;

	[SerializeField]
	private GameObject gameOverPanel;
	// Use this for initialization
	void Awake(){
		Time.timeScale = 0;
		_MakeInstance ();
	}
	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}
	public void _instructionButton() {
		Time.timeScale = 1;
		instructionButton.gameObject.SetActive (false);
	}
	public void _setScore(int score){
		scoreText.text = "" + score;
	}
	public void _birdDead(int score){
		gameOverPanel.SetActive (true);
        endScoreText.text = "" + score;
        if (gameManager.instance != null)
        {
            if (score > gameManager.instance._getHighScore())
            {
                gameManager.instance._setHighScore(score);
            }
            bestscoreText.text = "" + gameManager.instance._getHighScore();
        }
        
    }
	public void _menuButton(){
		//Application.LoadLevel ("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
	public void _restart(){
        SceneManager.LoadScene("GamePlay");
    }
}
