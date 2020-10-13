using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject NextLevel;
    public GameObject NextLevelButton;
    public bool isInputEnabled;
    public int roundTrack;
    public int roundTrackMax;
    public compassCheck compassCheckREF;
    //public ArrayList gridArray;
    public List<GameObject> myList = new List<GameObject>();
    public Text pressSpace;
    public Text wallText;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        NextLevel.SetActive(false);
        NextLevelButton.SetActive(false);
        isInputEnabled = true;
    }

    public IEnumerator checkCompassRepeat()
    {
           while (roundTrack < roundTrackMax)
           {
			//Debug.Log("Started Coroutine at timestamp : " + Time.time);
			//compassCheckREF.checkCompass();
                yield return new WaitForSecondsRealtime(1f);
                roundTrack = roundTrack + 1;
                //System.Windows.Forms.SendKeys.Send("{z}");

            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
           }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
            StartCoroutine(checkCompassRepeat());
		}

          if (roundTrack == roundTrackMax)
     {
          NextLevel.SetActive(true);
          NextLevelButton.SetActive(true);
          isInputEnabled = false;
        }
        if (Input.GetKeyUp("space") && isInputEnabled == true && compassCheckREF.statueExist == true)
        {
            roundTrack++;
            pressSpace.enabled = false;
        }
        if (Input.GetKeyUp("r"))
        {
            resetRound();
        }
        if (Input.GetMouseButtonDown(0))
        {
            wallText.enabled = false;
        }

            void resetRound()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
