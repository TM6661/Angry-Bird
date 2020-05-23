using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    private Scene scene;
    private string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void Test()
    {
        Debug.Log("Function work properly");
    }
}
