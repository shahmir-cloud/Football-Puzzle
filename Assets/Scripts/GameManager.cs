using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TMP_Text Goal;
    public TMP_Text Level;

    public bool gameover ;
    public Image GameOverImage;
    public Image Pause;
    UIManager UI;
    // Start is called before the first frame update
    void Start()
    {
        gameover = true;
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UI.level==1)
        {
            Goal.text = "Goal Left " + UI.GoalLeft + " /5";
        }
        else if(UI.level == 2)
        {
            Goal.text = "Goal Left " + UI.GoalLeft + " /10";
        }
        else if (UI.level == 3)
        {
            Goal.text = "Goal Left " + UI.GoalLeft + " /13";
        }
        else if (UI.level == 4)
        {
            Goal.text = "Goal Left " + UI.GoalLeft + " /15";
        }
        else if (UI.level == 5)
        {
            Goal.text = "Goal Left " + UI.GoalLeft + " /25";
        }
        Level.text = "Level " + UI.level ;
        chaekstatus();
    }
    public void OnPausee()
    {
        gameover = true;
        Pause.gameObject.SetActive(true);
    }
    public void OnRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnResume()
    {
        gameover = false;
        Pause.gameObject.SetActive(false);
    }
    public void OnQuit()
    {
        SceneManager.LoadScene("New Scene");
    }
    public void chaekstatus()
    {
        if(UI.chance<1)
        {
           GameOverImage.gameObject.SetActive(true);
        }
    }
    
}
