using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    //public GameObject sound;
    private AudioSource audio;
    public Text score;
    public Image image;
    public Snake snake;
    public bool menu_create = false;
    int t1;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (snake == null&& menu_create==false)
        {
            //sound.gameObject.SetActive(false);
            audio.Play();
            menu_create = true;
            image.gameObject.SetActive(true);
            t1 = snake.tailCount - 1;
            score.text = "колличество очков: " + t1;
           
        }
    }
}
