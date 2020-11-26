using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public Button Start;

	public void StartGame() {
	// 	Button btn = Start.GetComponent<Button>();
	// 	btn.onClick.AddListener(TaskOnClick);
	// }

	// void TaskOnClick(){
			SceneManager.LoadScene("SampleScene");
	}


}