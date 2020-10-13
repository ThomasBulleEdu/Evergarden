using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class compassCheck : MonoBehaviour
{
    public GameObject NorthCheck;
    public GameObject EastCheck;
    public GameObject SouthCheck;
    public GameObject WestCheck;
    public GameObject thisStatue;
    public sceneManager sceneManagerREF;
    public string hitName;
    public bool isClear = true;
    public bool isWet = false;
    public bool isNorthReady = false;
    public bool isEastReady = false;
    public bool isSouthReady = false;
    public bool isWestReady = false;
    public bool isCat = false;
    public bool isStatue = false;
    public bool falseCheck = false;
    public bool catIsWet = false;
    public bool statueExist = false;
    public Sprite cat;
    public int one = 1;

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

        if (isCat == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.yellow, Color.red, .5f);

            this.GetComponent<SpriteRenderer>().sprite = cat;
            }
        checkCompass();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space") && catIsWet == false)
        {
            checkCompass();
        }
        checkReady();
        if (statueExist == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                 Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
                 Vector3 direction = worldMousePosition - Camera.main.transform.position;
                 RaycastHit hit;
                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Debug.Log("You selected the " + hit.transform.name);
                    hitName = hit.transform.name;
                    GetGameObject();
                }
            }
        }



    }
    //   ParentScript.ScriptFunction();


    public void checkCompass()
    {
        if (isCat == false)
        {
            if (isClear == true && isWet == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.blue;
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
            if (NorthCheck.GetComponent<SpriteRenderer>().material.color == Color.blue || EastCheck.GetComponent<SpriteRenderer>().material.color == Color.blue || SouthCheck.GetComponent<SpriteRenderer>().material.color == Color.blue || WestCheck.GetComponent<SpriteRenderer>().material.color == Color.blue)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.blue;
                isClear = false;
                sceneManagerREF.GameOver.SetActive(true);
                sceneManagerREF.isInputEnabled = falseCheck;
                catIsWet = true;
            }
            /*    else if (isStatue == true)
                    {
                        isClear = false;
                    }*/
        }
        if (isStatue == false)
        {
            if (isClear == true && isWet == true)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.blue;
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
        else if (isStatue == true)
        {
            Debug.Log("Ping");
        }
    }



    void checkReady()
    {
        if(isClear == true)
        {
            if (NorthCheck.GetComponent<SpriteRenderer>().material.color == Color.blue || EastCheck.GetComponent<SpriteRenderer>().material.color == Color.blue || SouthCheck.GetComponent<SpriteRenderer>().material.color == Color.blue || WestCheck.GetComponent<SpriteRenderer>().material.color == Color.blue)
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

    void GetGameObject()
    {
        if(statueExist == false)
        {


            thisStatue = GameObject.Find(hitName);

            if (thisStatue.GetComponent<compassCheck>().isClear == true)
            {


                thisStatue.GetComponent<compassCheck>().isStatue = true;
                //thisStatue.GetComponent<compassCheck>().isClear = false;
                thisStatue.GetComponent<SpriteRenderer>().material.color = Color.gray;
                statueExist = true;
                StartCoroutine(checkCompassRepeat());
            }
        }


    }

    public IEnumerator checkCompassRepeat()
    {

           yield return new WaitForSecondsRealtime(1f);
        thisStatue.GetComponent<compassCheck>().isClear = false;

    }
}
