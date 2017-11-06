using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	
	[SerializeField]
	private Text highscoreText;

	public void Start(){
		int highscore = PlayerPrefs.GetInt ("highscore", 0);
		this.highscoreText.text = highscore.ToString();

		LTDescr tween = LeanTween.scale (this.highscoreText.gameObject, Vector3.one,0.5f);
		tween.setEase (LeanTweenType.easeOutBounce);
		tween.setFrom (Vector3.one * 5);
	}

	public void RetryButtonClick() {
		SceneManager.LoadScene ("MainScene");
	}
}
