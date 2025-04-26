using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public string Scene;
    public void NextScene()
    {
        SceneManager.LoadScene(Scene);
    }
}