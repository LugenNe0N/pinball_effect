using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Control : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartButtonPressed()
    {
        Debug.Log("Start Button is pressed");
        SceneManager.LoadScene("main");
    }

    public void TitleButtonPressed()
    {
        Debug.Log("Title Button is pressed");
        SceneManager.LoadScene("Title");
    }

    public void RestartButtonPressed()
    {
        Debug.Log("Retart Button is pressed");
        SceneManager.LoadScene("main");
    }

    public void QuitButtonPressed()
    {
        Debug.Log("Quit Button is pressed");

        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
