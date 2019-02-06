using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    static GameManager instance;

    public Scene[] scene;
    public bool isPlaying = true;

    int curScene = 0;
    Vector2 entrancePos;

    public string[] sceneName;

    [Header("패널")]
    public GameObject InGameOption;
    public GameObject MapPanel;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPlaying)
            {
                Time.timeScale = 0f;
                isPlaying = false;

                InGameOption.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                isPlaying = true;

                InGameOption.SetActive(false);
            }
        }else if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (MapPanel.activeInHierarchy)
            {
                MapPanel.SetActive(false);
            }
            else
            {
                MapPanel.SetActive(true);
            }
        }	
	}

    public static GameManager GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<GameManager>();
        }
        return instance;
    }

    public void LoadScene(int sceneNum, int entrance)
    {
        entrancePos = scene[sceneNum].entrancePos[entrance];
        Debug.Log(entrancePos);
        SceneManager.LoadScene(sceneName[sceneNum]);
    }
}

[System.Serializable]
public class Scene
{
    public Vector2[] entrancePos;
}
