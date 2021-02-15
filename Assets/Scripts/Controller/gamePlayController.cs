using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gamePlayController : MonoBehaviour {

	public static gamePlayController instance;
	[SerializeField]
	private Button instructionButton;

	[SerializeField]
	private Text scoreText,endScoreText,bestscoreText;

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
	public void _InstructionButton() {
		Time.timeScale = 1;
		instructionButton.gameObject.SetActive (false);
	}
	public void _setScore(int score){
		scoreText.text = "" + score;
	}
	public void _birdDead(){
		gameOverPanel.SetActive (true);
	}
	public void _menuButton(){
		Application.LoadLevel ("MainMenu");	
	}
	public void _restart(){
		Application.LoadLevel ("GamePlay");	
	}
}
