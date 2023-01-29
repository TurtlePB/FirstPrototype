using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IPointerDownHandler
{
    public static LevelManager Instance;
    public string sceneName;
    private float clickCoolDown;

    // [SerializeField] private GameObject _loaderCanvas;
    // [SerializeField] private Image _progressBar;
    void Awake()
    {
        // if (Instance == null)
        // {
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
        clickCoolDown = 5;
    }

    // public async void LoadScene(string sceneName)
    // {
    //     var scene = SceneManager.LoadSceneAsync(sceneName);
    //     scene.allowSceneActivation = false;
    // }

    // public void GoNextScene()
    // {
    //     SceneManager.LoadScene(sceneName); 
    // }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneName);
        // clickCoolDown -= Time.deltaTime;
        // if (clickCoolDown <= 0)
        // {
        //     clickCoolDown = 5;
        // }
    }
}
