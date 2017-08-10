using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter_Area : MonoBehaviour {
	public string level;
	public Scene scene;

	// Update is called once per frame
	void Update (){ 
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown ("up")) {
				scene = SceneManager.GetSceneAt (0);

				SceneManager.MoveGameObjectToScene (col.gameObject, scene);
				SceneManager.LoadScene (level, LoadSceneMode.Single);
			}
		}
	}
}
