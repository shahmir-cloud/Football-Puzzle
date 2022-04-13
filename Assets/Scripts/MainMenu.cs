using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Image Mainmenuu;
    public Image How;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onstart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnHowto()
    {
        this.gameObject.SetActive(false);
        How.gameObject.SetActive(true);
    }
    public void Back()
    {
        this.gameObject.SetActive(false);
        Mainmenuu.gameObject.SetActive(true);
    }
}
