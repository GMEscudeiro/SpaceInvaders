using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GoodEnding" || scene.name == "BadEnding"){
            if(Input.GetKey(KeyCode.Space)){
                GameManager.RestartGame();
            }
        }
    }
}
