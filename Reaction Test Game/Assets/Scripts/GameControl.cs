using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class GameControl : MonoBehaviour
{
    public GameObject GreenDot;
    public GameObject RedDot;
    public GameObject Cross;
    public GameObject TextTop;
    public GameObject TextBottom;
    public GameObject SampleRed;
    public GameObject SampleGreen;
    public SpriteRenderer BG;
    public Text gametext;

    


    private float starttime = 0f;
    private char[] ColorArray;
    private float TempRandomno = 0f;
    private int t = 3;
    private int tempT;
    private bool EntryVar = true;
    private bool dataentry = true;

    public float reactionTime = 0f;

    void Datawrite()
    {
        string path = Application.dataPath + "/log.csv";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "TimeStamp,ReactionTime");
        }
        if (dataentry)
        {
            string blankdata = "\n" + ",";
            File.AppendAllText(path, blankdata);
            dataentry = false;
        }

        string newdata = "\n" + System.DateTime.Now + "," + reactionTime.ToString();

        File.AppendAllText(path, newdata);
    }


    private void Start()
    {

    }

    private void FixedUpdate()
    {
        int i = (int)Time.time / 1;
        if (i == t && SampleRed.active == true && SampleRed.active == true && SampleGreen.active == true && TextTop.active == true && TextBottom.active == true)
        {
            SampleGreen.SetActive(false);
            SampleRed.SetActive(false);
            TextTop.SetActive(false);
            TextBottom.SetActive(false);
            BG.color = Color.white;
            tempT = t + 54;
        }
        else if (i == t + 1)
        {
            gametext.text = "3 . .";
        }
        else if (i == t + 2)
        {
            gametext.text = ". 2 .";
        }
        else if (i == t + 3)
        {
            gametext.text = ". . 1";
        }
        if (i == t + 4)
        {
            gametext.text = "";
            Cross.SetActive(true);
        }
        if (i > t + 4 && i < tempT)
        {
            TempRandomno = Random.Range(-1.0f, 1.0f);
            t += 1;
            if (TempRandomno >= 0 && EntryVar)
            {
                Instantiate(GreenDot, this.transform.position, Quaternion.identity);
                EntryVar = false;
                starttime = Time.time;
            }
            else
            {
                Instantiate(RedDot, this.transform.position, Quaternion.identity);
            }
        }


        if (Input.GetMouseButtonDown(0) && !EntryVar)
        {
            reactionTime = Time.time - starttime;
            EntryVar = true;
            Debug.Log(reactionTime.ToString() + " sec");
            Datawrite();
        }
    }


    /*
    private void FixedUpdate()
    {
        int i = (int)Time.time / 1;
        if (i == t && SampleRed.active == true && SampleRed.active == true && SampleGreen.active == true && TextTop.active == true && TextBottom.active == true)
        {
            SampleGreen.SetActive(false);
            SampleRed.SetActive(false);
            TextTop.SetActive(false);
            TextBottom.SetActive(false);
            BG.color = Color.white;
            tempT = t + 54;
        }
        else if ( i == t+1 )
        {
            gametext.text = "3 . .";
        }
        else if ( i == t+2 )
        {
            gametext.text = ". 2 .";
        }
        else if ( i == t+3 )
        {
            gametext.text = ". . 1";
        }
        if (i == t+4)
        {
            gametext.text = "";
            Cross.SetActive(true);
        }
        if (i > t+4 && i < tempT)
        {
            TempRandomno = Random.Range(-1.0f, 1.0f);
            t += 1;
            if (TempRandomno >= 0 && EntryVar)
            {
                Instantiate(GreenDot, this.transform.position, Quaternion.identity);
                EntryVar = false;
                starttime = Time.time;
            }
            else
            {
                Instantiate(RedDot, this.transform.position, Quaternion.identity);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && !EntryVar)
        {
            reactionTime = Time.time - starttime;
            EntryVar = true;
            Debug.Log(reactionTime.ToString() + " sec");
        }
    }
    */

    /*
    private IEnumerator StartMeasuring()
    {
         = Random.Range(0.5f, 4f);
        yield return new WaitForSeconds(randomDelayBeforeStart);
        WhiteRect.color = Color.green;
        starttime = Time.time;
        isclockticking = true;
        istimerstoppable = true;
    }*/


    /*
    [SerializeField]
    private Text gametext;

    

    [SerializeField]
    private SpriteRenderer WhiteRect;

    private float rxntime, starttime, randomDelayBeforeStart;

    private bool isclockticking, istimerstoppable;

    
    // Start is called before the first frame update
    void Start()
    {
        rxntime = 0.0f;
        starttime = 0.0f;

        gametext.text = "";
        isclockticking = false;
        istimerstoppable = true;
    }


    // Update is called once per frame
    void Update()
    {
        
        
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!isclockticking)
            {
                StartCoroutine("StartMeasuring");
                gametext.text = "Wait for GREEN";
                WhiteRect.color = Color.red;
                isclockticking = true;
                istimerstoppable = false;
            }
            else if (isclockticking && istimerstoppable)
            {
                StopCoroutine("StartMeasuring");
                rxntime = Time.time - starttime;
                gametext.text = "Your Reaction Time is : \n" + rxntime.ToString("N4") + " sec\n" + "Click to start again";
                isclockticking = false;
            }
            else if (isclockticking && !istimerstoppable)
            {
                StopCoroutine("StartMeasuring");
                rxntime = 0f;
                isclockticking = false;
                istimerstoppable = true;
                gametext.text = "Too Early\n" + "Click to start again";
            }
        }
    }

    private IEnumerator StartMeasuring()
    {
            randomDelayBeforeStart = Random.Range(0.5f, 4f);
            yield return new WaitForSeconds(randomDelayBeforeStart);
            WhiteRect.color = Color.green;
            starttime = Time.time;
            isclockticking = true;
            istimerstoppable = true;
    }*/
}   
