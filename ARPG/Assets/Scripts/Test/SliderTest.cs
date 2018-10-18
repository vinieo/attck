using UnityEngine;
using System.Collections;

public class SliderTest : MonoBehaviour {
	public AudioSource audioSource;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// slider事件
	/// </summary>
	/// <param name="value">Value.</param>
	public void SliderValueChange(float value){
		audioSource.volume = value;
	}
}
