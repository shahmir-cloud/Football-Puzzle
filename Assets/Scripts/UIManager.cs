using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject[] BallPrefabs;
    private float xvalue ;
    private float zvalue ;
    public float time = 0;
    public bool activate = true;
    public static int num = 0;
    public int level ;
    public int Ballnum = 0;
    public int GoalLeft = 25;
    public int chance = 5;
    public bool level_complete = false;
    public bool Goal1full = false;
    public bool Goal2full = false;
    public bool Goal3full = false;
    public bool Goal4full = false;
    public bool Goal5full = false;
    public bool win = false;

    BallController ball;
    public Slider slide;

    public Image image;
    public Image levelimage;
    public Image Startlevel;
    public Image Pauselevel;
    public Image GameComplete;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    public TMP_Text Level;
    public TMP_Text Timee;
    public TMP_Text Balls;
    public TMP_Text Chance;

    public TMP_Text Levelpause;
    public TMP_Text Levelstart;
    public TMP_Text Levelcomp;
    public TMP_Text Timetaken;
    public TMP_Text BallLeft;

    GameManager game;
    // Start is called before the first frame update
    
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>();
        slide.maxValue = 30f;
        slide.minValue = 20f;
        num++;
        level = num;
        Debug.Log(num);
        //level = PlayerPrefs.GetInt("level");
        //level++;
    }

    // Update is called once per frame
    void Update()
    {
        if(level==1)
        {
            levelimage.GetComponent<Image>().sprite = sprite1;
            Pauselevel.GetComponent<Image>().sprite = sprite1;
            GoalLeft = 5;
        }
        else if(level == 2)
        {
            levelimage.GetComponent<Image>().sprite = sprite2;
            Pauselevel.GetComponent<Image>().sprite = sprite2;
            GoalLeft = 10;
        }
        else if (level == 3)
        {
            levelimage.GetComponent<Image>().sprite = sprite3;
            Pauselevel.GetComponent<Image>().sprite = sprite3;
            GoalLeft = 13;

        }
        else if (level == 4)
        {
            levelimage.GetComponent<Image>().sprite = sprite4;
            Pauselevel.GetComponent<Image>().sprite = sprite4;
            GoalLeft = 15;
        }
        else if (level == 5)
        {
            levelimage.GetComponent<Image>().sprite = sprite5;
            Pauselevel.GetComponent<Image>().sprite = sprite5;
            GoalLeft = 25;
        }
        
        Level.text = "Levels :" + level;
        Balls.text = "Balls :" + Ballnum;
        Chance.text = "Chance :" + chance;
        Levelstart.text= "Level " + level ;
        Levelcomp.text = "Level " + level + " Completed";
        Levelpause.text="Level" + level + " Paused";
        //Timetaken.text = "Time Taken : " ;
        BallLeft.text = "Ball Left : " + Ballnum;
        
        CheakVictory();
        if (game.gameover == false)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
    }

    public void Ball1()
    {
        if(activate)
        {
            activate = false;
            Instantiate(BallPrefabs[1], GenerateSpawnPosition(), BallPrefabs[0].transform.rotation);
            Ballnum++;
        }
    }

    public void Ball2()
    {
        if(activate)
        {
            activate = false;
            Instantiate(BallPrefabs[0], GenerateSpawnPosition(), BallPrefabs[1].transform.rotation);
            Ballnum++;
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
       float xvalue = Random.Range(-25, 25);
       float zvalue = Random.Range(-19, 10);
    Vector3 randompos = new Vector3(xvalue, 3, zvalue);
        return randompos;
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Timee.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        Timetaken.text = "Time Taken :" + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void CheakVictory()
    {
        if (Goal1full && Goal2full && Goal3full && Goal4full && Goal5full)
        {
            if(level==5)
            {
                GameComplete.gameObject.SetActive(true);
                game.gameover = true;
            }
            else
            {
                image.gameObject.SetActive(true);
                game.gameover = true;
            }
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartPlay()
    {
        Startlevel.gameObject.SetActive(false);
        game.gameover = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        num = 0;    
    }
}
