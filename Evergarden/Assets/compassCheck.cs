using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class compassCheck : MonoBehaviour
{
    public GameObject NorthCheck;
    public GameObject EastCheck;
    public GameObject SouthCheck;
    public GameObject WestCheck;
    public GameObject GameOver;
    public GameObject NextLevel;
    public int roundTrack;
    public bool isClear = true;
    public bool isWet = false;
    public bool isNorthReady = false;
    public bool isEastReady = false;
    public bool isSouthReady = false;
    public bool isWestReady = false;
    public bool isCat = false;

   /* public Color Blue;
    public Color Purple;
    public Color Yellow;
    public Color White;
    public Color Orange;
    public Color Cat;
    public Color Butterfly;*/

    // Start is called before the first frame update
    void Start()
    {
        //        ParentScript = this.transform.parent.GameObject.GetComponent<ScriptName>();
        GameOver.SetActive(false);
        NextLevel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (roundTrack == 10)
        {
            NextLevel.SetActive(true);
        }
        if (Input.GetKeyUp("z"))
        {
            checkCompass();
            roundTrack++;
        }
        if (Input.GetKeyUp("r"))
        {
            resetRound();
        }
        checkReady();

    }
 //   ParentScript.ScriptFunction();


    void checkCompass()
    {
        if (isCat == false)
        {
            if (isClear == true && isWet == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.cyan;
                isClear = false;
            }
            else if (isClear == true && isNorthReady == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.magenta;
                isClear = false;
            }
            else if (isClear == true && isEastReady == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.red;
                isClear = false;
            }
            else if (isClear == true && isSouthReady == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.white;
                isClear = false;
            }
            else if (isClear == true && isWestReady == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.yellow;
                isClear = false;
            }
        }
        else if (isCat == true)
        {
            if (isClear == true && isWet == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.cyan;
                isClear = false;
                GameOver.SetActive(true);
            }
            else if (isClear == true && isNorthReady == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.magenta;
                isClear = false;
                GameOver.SetActive(true);
            }
            else if (isClear == true && isEastReady == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.red;
                isClear = false;
                GameOver.SetActive(true);
            }
            else if (isClear == true && isSouthReady == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.white;
                isClear = false;
                GameOver.SetActive(true);
            }
            else if (isClear == true && isWestReady == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.yellow;
                isClear = false;
                GameOver.SetActive(true);
            }
        }
    }
    void checkReady()
    {    
        if(isClear == true) 
        {    
            if (NorthCheck.GetComponent<SpriteRenderer>().material.color == Color.cyan || EastCheck.GetComponent<SpriteRenderer>().material.color == Color.cyan || SouthCheck.GetComponent<SpriteRenderer>().material.color == Color.cyan || WestCheck.GetComponent<SpriteRenderer>().material.color == Color.cyan)
                {
                    isWet = true; 
                }
            else if(NorthCheck.GetComponent<SpriteRenderer>().material.color == Color.white)
            {
                isSouthReady = true;
            }
            else if (EastCheck.GetComponent<SpriteRenderer>().material.color == Color.yellow)
            {
                isWestReady = true;
            }
            else if (SouthCheck.GetComponent<SpriteRenderer>().material.color == Color.magenta)
            {
                isNorthReady = true;
            }
            else if (WestCheck.GetComponent<SpriteRenderer>().material.color == Color.red)
            {
                isEastReady = true;
            }
        }
    }
    void resetRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
