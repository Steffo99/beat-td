using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void Play () {
        SceneManager.LoadScene("Game");
        Scene menu = SceneManager.GetSceneByName("Menu");
        Scene game = SceneManager.GetSceneByName("Game");
        SceneManager.SetActiveScene(game);
        SceneManager.UnloadSceneAsync(menu);
	}
}
