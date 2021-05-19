using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoder : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            jumpToMainScreen();
    }
    private void jumpToMainScreen() {
        SceneManager.LoadScene(0);
    }

    public void loadCurrentLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        
    }
}
