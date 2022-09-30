using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static void LoadScene(int sceneindex) => SceneManager.LoadScene(sceneindex);

	public static void LoadScene(string scenename) => SceneManager.LoadScene(scenename);

	public static void Quit() => Application.Quit();
}
