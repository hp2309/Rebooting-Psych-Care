using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{
    public Sprite[] cards;
    public Sprite cardholder;
    public GameObject DealerDeck;
    public SpriteRenderer Dealer;
    public SpriteRenderer Pile1;
    public SpriteRenderer Pile2;
    public SpriteRenderer Pile3;
    public SpriteRenderer Pile4;
    public GameObject gametext;
    public Text gtext;
    public GameObject nextbutton;

    private string currentscenename;

    private int last;
    private Sprite currentsprite;
    private int randomindex;
    private Sprite prevsprite;


    private string currentspritename;
    private int moveno = 1;
    private float reactiontime = 0f;
    private int destpileno = 0;

    private float starttime =0f;
    private bool isrunover = true;

    // Start is called before the first frame update
    void Start()
    {
        gtext.text = "Press SpaceBar to start";
        currentscenename = SceneManager.GetActiveScene().name;
        last = cards.Length;
        Debug.Log(last.ToString());
        Pile1.sprite = cardholder;
        Pile2.sprite = cardholder;
        Pile3.sprite = cardholder;
        Pile4.sprite = cardholder;
        randomindex = Random.Range(0, last);
        currentsprite = cards[randomindex];
        viewsprite();
        last -= 1;
        Debug.Log(last.ToString());
    }

    void Datawrite()
    {
        string path = Application.dataPath + "/log.csv";

        if (!File.Exists(path))
        {
            string header = "RUN,MoveNo,SpriteName,MovedToPile,ReactionTime";
            File.WriteAllText(path, header);
        }

        string newdata = "\n" + currentscenename + "," + moveno.ToString() + "," + currentspritename + "," + destpileno.ToString() + "," + reactiontime.ToString();

        moveno += 1;

        File.AppendAllText(path, newdata);
    }


    void viewsprite()
    {
        Dealer.sprite = currentsprite;
        currentspritename = currentsprite.name;
        Debug.Log(currentspritename);
    }

    void spriteswap()
    {
        cards[randomindex] = cards[last - 1];
        cards[last - 1] = currentsprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gametext.SetActive(false);
            DealerDeck.SetActive(true);
            starttime = Time.time;
            isrunover = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isrunover)
        {
            if (last == 0)
            {
                gtext.text = "All cards have been Sorted!";
                gametext.SetActive(true);
                nextbutton.SetActive(true);
                isrunover = true;
                Dealer.sprite = cardholder;
            }
            else
            {
                prevsprite = currentsprite;
                Pile1.sprite = prevsprite;
                destpileno = 1;
                Datawrite();
                randomindex = Random.Range(0, last);
                currentsprite = cards[randomindex];
                reactiontime = Time.time - starttime;
                Debug.Log(reactiontime.ToString());
                viewsprite();
                starttime = Time.time;

                spriteswap();



                if (last > 0)
                {
                    Debug.Log(last.ToString() + "   " + randomindex.ToString());
                    last -= 1;
                }
            }
            if (last == 0)
            {
                prevsprite = currentsprite;
                Pile1.sprite = prevsprite;
                destpileno = 1;
                Datawrite();
                reactiontime = Time.time - starttime;
                Debug.Log(reactiontime.ToString());
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isrunover)
        {
            if (last == 0)
            {
                gtext.text = "All cards have been Sorted!";
                gametext.SetActive(true);
                nextbutton.SetActive(true);
                isrunover = true;
                Dealer.sprite = cardholder;
            }
            else
            {
                prevsprite = currentsprite;
                Pile3.sprite = prevsprite;
                destpileno = 3;
                Datawrite();
                randomindex = Random.Range(0, last);
                currentsprite = cards[randomindex];
                reactiontime = Time.time - starttime;
                Debug.Log(reactiontime.ToString());
                viewsprite();
                starttime = Time.time;

                spriteswap();

                if (last > 0)
                {
                    Debug.Log(last.ToString() + "   " + randomindex.ToString());
                    last -= 1;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isrunover)
        {
            if (last == 0)
            {
                gtext.text = "All cards have been Sorted!";
                gametext.SetActive(true);
                nextbutton.SetActive(true);
                isrunover = true;
                Dealer.sprite = cardholder;
            }
            else
            {
                prevsprite = currentsprite;
                Pile4.sprite = prevsprite;
                destpileno = 4;
                Datawrite();
                randomindex = Random.Range(0, last);
                currentsprite = cards[randomindex];
                reactiontime = Time.time - starttime;
                Debug.Log(reactiontime.ToString());
                viewsprite();
                starttime = Time.time;

                spriteswap();

                if (last > 0)
                {
                    Debug.Log(last.ToString() + "   " + randomindex.ToString());
                    last -= 1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isrunover)
        {
            if (last == 0)
            {
                gtext.text = "All cards have been Sorted!";
                gametext.SetActive(true);
                nextbutton.SetActive(true);
                isrunover = true;
                Dealer.sprite = cardholder;
            }
            else
            {
                prevsprite = currentsprite;
                Pile2.sprite = prevsprite;
                destpileno = 2;
                Datawrite();
                randomindex = Random.Range(0, last);
                currentsprite = cards[randomindex];
                reactiontime = Time.time - starttime;
                Debug.Log(reactiontime.ToString());
                viewsprite();
                starttime = Time.time;

                spriteswap();

                if (last > 0)
                {
                    Debug.Log(last.ToString() + "   " + randomindex.ToString());
                    last -= 1;
                }
            }
        }
        
    }
}
