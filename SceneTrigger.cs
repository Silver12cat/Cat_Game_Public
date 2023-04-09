using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTrigger : MonoBehaviour
{

    public GameObject loadingScreen;
    public Collider2D other;
    public string SceneName;
    public Vector3 SpotInScene;
    public Vector3 RotationInScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            
                StartCoroutine(LoadScene());
        }
    }


    public IEnumerator LoadScene()
    {
        loadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        asyncLoad.allowSceneActivation = false;
        PositionHandler();
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                asyncLoad.allowSceneActivation = true;

                Time.timeScale = 1f;
            }
            yield return null;
        }
        

        Time.timeScale = 1f;
    }

    public void PositionHandler()
    {
        GameManager.Instance.SpawnLocation = SpotInScene;
        GameManager.Instance.SpawnRotation = RotationInScene;
    }
}
