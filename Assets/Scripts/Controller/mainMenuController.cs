using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
public class mainMenuController : MonoBehaviour {

	public void _playButton(){
		Application.LoadLevel ("GamePlay");
		//SceneManager.LoadScene ("GamePlay");
	}
}
