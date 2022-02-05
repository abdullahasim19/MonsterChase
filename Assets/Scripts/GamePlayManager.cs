using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;

    public static GamePlayManager instance;

    private int index;
    public int characterIndex
    {
        set
        {
            index = value;
        }
        get
        {
            return index;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += LoadingFinsihed;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadingFinsihed;
    }
    void LoadingFinsihed(Scene scene,LoadSceneMode mode)
    {
        if(scene.name=="GamePlay")
        {
            characters[characterIndex].transform.position = new Vector2(-0.1215843f, 2.734597f);
            Instantiate(characters[characterIndex]);
        }
    }
}
