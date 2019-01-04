using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float nextSceneDelay = 0f;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start(){
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0){
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(nextSceneDelay);
        LoadNextScene();
    }

    public void LoadNextScene(){
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


}
