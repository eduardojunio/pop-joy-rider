using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	private static AudioManager instance;

	[SerializeField]
	private AudioSource sfxAudioSource;

	[SerializeField]
	private AudioSource backgroundMusicAudioSource;

	[SerializeField]
	private AudioClip[] coinsAudioClips;

	public void Awake(){
		AudioManager.instance = this;
	}

	public static AudioManager GetInstance() {
		return instance;
	}

	public void PlayCoinAudioSource() {
		int index = Random.Range (0, coinsAudioClips.Length);
		PlaySfx (coinsAudioClips [index]);
	}
		
	private void PlaySfx(AudioClip audioClip){
		sfxAudioSource.clip = audioClip;
		sfxAudioSource.loop = false;
		sfxAudioSource.Stop ();
		sfxAudioSource.Play ();
	}

	private void PlayBackground(AudioClip audioClip){
		backgroundMusicAudioSource.clip = audioClip;
		backgroundMusicAudioSource.loop = true;
		backgroundMusicAudioSource.Stop ();
		backgroundMusicAudioSource.Play ();
	}

}
