using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject NextLevel;
    public bool isInputEnabled;
    public int roundTrack;
    public int roundTrackMax = 16;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        NextLevel.SetActive(false);
        isInputEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (roundTrack == roundTrackMax)
        {
            NextLevel.SetActive(true);
            isInputEnabled = false;
        }
        if (Input.GetKeyUp("z") && isInputEnabled == true)
        {
            roundTrack++;
        }
        if (Input.GetKeyUp("r"))
        {
            resetRound();
        }

    void resetRound()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
