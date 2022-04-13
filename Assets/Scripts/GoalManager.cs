using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    private int Goal1count = 0;
    private int Goal2count = 0;
    private int Goal3count = 0;
    private int Goal4count = 0;
    private int Goal5count = 0;
    
    private string name;
    public string[,] goals =new string[5,5] {
         {"","","","",""},
         {"","","","",""},
         {"","","","",""},
         {"","","","",""},
         {"","","","",""},
         }; 
    public string[,] level1 = new string[5,5] {
         {"Ball1","","","",""},
         {"Ball1","","","",""},
         {"Ball1","","","",""},
         {"Ball1","","","",""},
         {"Ball1","","","",""},
         };
    public string[,] level2 = new string[5,5] {
         {"Ball1","Ball1","Ball1","Ball1","Ball1"},
         {"","","","",""},
         {"","","","",""},
         {"","","","",""},
         {"Ball2","Ball2","Ball2","Ball2","Ball2"},
         };
    public string[,] level3 = new string[,] {
         {"Ball1","Ball2","Ball2","Ball2","Ball2"},
         {"Ball1","","","",""},
         {"Ball1","","","",""},
         {"Ball1","","","",""},
         {"Ball1","Ball2","Ball2","Ball2","Ball2"},
         };
    public string[,] level4 = new string[,] {
         {"Ball1","Ball1","Ball1","Ball1","Ball1"},
         {"","","","",""},
         {"Ball2","Ball2","Ball2","Ball2","Ball2"},
         {"","","","",""},
         {"Ball1","Ball1","Ball1","Ball1","Ball1"},
         };
    public string[,] level5 = new string[,] {
         {"Ball1","Ball2","Ball1","Ball2","Ball1"},
         {"Ball2","Ball1","Ball2","Ball1","Ball2"},
         {"Ball1","Ball2","Ball1","Ball2","Ball1"},
         {"Ball2","Ball1","Ball2","Ball1","Ball2"},
         {"Ball1","Ball2","Ball1","Ball2","Ball1"},
         };
    UIManager UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Goal1"))
        {
            name = other.tag;
            if (Goal1count < 5 && cheakvalue(0, Goal1count, name))
            {
                addvalue(0, Goal1count, name);
                Goal1count++;
                cheakarray(UI.level);
            }
            else
            {
                Destroy(other.gameObject);
                UI.chance--;
            }

        }
        else if(gameObject.CompareTag("Goal2"))
        {
            name = other.tag;
            if (Goal2count < 5 && cheakvalue(1, Goal2count, name))
            {
                addvalue(1, Goal2count, name);
                Goal2count++;
                cheakarray(UI.level);
            }
            else
            {
                Destroy(other.gameObject);
                UI.chance--;
            }
        }
        else if (gameObject.CompareTag("Goal3"))
        {
            name = other.tag;
            if (Goal3count < 5 && cheakvalue(2, Goal3count, name))
            {
                addvalue(2, Goal3count, name);
                Goal3count++;
                cheakarray(UI.level);
            }
            else
            {
                Destroy(other.gameObject);
                UI.chance--;
            }
        }
        else if (gameObject.CompareTag("Goal4"))
        {
            name = other.tag;
            if (Goal4count < 5 && cheakvalue(3, Goal4count, name))
            {
                addvalue(3, Goal4count, name);
                Goal4count++;
                cheakarray(UI.level);
            }
            else
            {
                Destroy(other.gameObject);
                UI.chance--;
            }
        }
        else if (gameObject.CompareTag("Goal5"))
        {
            name = other.tag;
            if(Goal5count < 5 && cheakvalue(4, Goal5count, name))
            {
                
                addvalue(4, Goal5count, name);
                Goal5count++;
                cheakarray(UI.level);
            }
            else
            {
                Destroy(other.gameObject);
                UI.chance--;
            }
        }
    }

    private void addvalue(int goalnum,int num, string value)
    {
        goals[goalnum, num] = value;
        Debug.Log("[ " + goalnum + " , " + num + " ] is " + goals[goalnum, num] + " but " + level1[goalnum, num]);
        UI.GoalLeft--;
    }
    private bool cheakvalue(int goalnum, int num, string value)
    {
        if(UI.level==1)
        {
            if (value == level1[goalnum, num])
            { return true; }
            else
            { return false; }
        }
        else if(UI.level == 2)
        {
            if (value == level2[goalnum, num])
            { return true; }
            else
            { return false; }
        }
        else if (UI.level == 3)
        {
            if (value == level3[goalnum, num])
            { return true; }
            else
            { return false; }
        }
        else if (UI.level == 4)
        {
            if (value == level4[goalnum, num])
            { return true; }
            else
            { return false; }
        }
        else if (UI.level == 5)
        {
            if (value == level5[goalnum, num])
            { return true; }
            else
            { return false; }
        }
        else
        {
            return false;
        }
    }
    public void cheakarray(int level)
    {
        if (level == 1)
        {
            if (Goal1count == 1){UI.Goal1full = true;}
            if (Goal2count == 1){UI.Goal2full = true;}
            if (Goal3count == 1){UI.Goal3full = true;}
            if (Goal4count == 1){UI.Goal4full = true;}
            if (Goal5count == 1){UI.Goal5full = true;}
        }
        else if(level == 2)
        {
            if (Goal1count == 5) { UI.Goal1full = true; }
            if (Goal2count == 0) { UI.Goal2full = true; }
            if (Goal3count == 0) { UI.Goal3full = true; }
            if (Goal4count == 0) { UI.Goal4full = true; }
            if (Goal5count == 5) { UI.Goal5full = true; }
        }
        else if (level == 3)
        {
            if (Goal1count == 5) { UI.Goal1full = true; }
            if (Goal2count == 1) { UI.Goal2full = true; }
            if (Goal3count == 1) { UI.Goal3full = true; }
            if (Goal4count == 1) { UI.Goal4full = true; }
            if (Goal5count == 5) { UI.Goal5full = true; }
        }
        else if (level == 4)
        {
            if (Goal1count == 5) { UI.Goal1full = true; }
            if (Goal2count == 0) { UI.Goal2full = true; }
            if (Goal3count == 5) { UI.Goal3full = true; }
            if (Goal4count == 0) { UI.Goal4full = true; }
            if (Goal5count == 5) { UI.Goal5full = true; }
        }
        else if (level == 5)
        {
            if (Goal1count == 5) { UI.Goal1full = true; }
            if (Goal2count == 5) { UI.Goal2full = true; }
            if (Goal3count == 5) { UI.Goal3full = true; }
            if (Goal4count == 5) { UI.Goal4full = true; }
            if (Goal5count == 5) { UI.Goal5full = true; }
        }
    }
}
