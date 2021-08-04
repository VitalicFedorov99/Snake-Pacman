using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
public class Snake : MonoBehaviour
{

    public GameObject sound;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public Image image;
    public Text text;
    public Text score;
    public int size = 16;
    public float shift = 1;
    public float timeoutMove = 0.5f;
    public float timeoutBonus = 5;
    public GameObject _tail;
    public GameObject _bonus;
    private float curTimeout;
    private Vector3[,] pos;
    private List<GameObject> tail;
    private Vector3 tail_pos;
    private Vector3 tail_last;
    private int t_Count;
    private float h, v;
    private AudioSource audio;
    private Animator animator;
    public int tailCount;
    public bool lose;
    public int t1;
    public bool menu_create=false;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        lose = false;
        tailCount = 1;
        t_Count = tailCount;
        tail = new List<GameObject>();
        tail.Add(this.gameObject);
     
    }


    void Move(int count)
    {
        tail_last = tail[tail.Count - 1].transform.position;

        tail_pos = tail[0].transform.position;
        tail[0].transform.position = new Vector3( tail_pos.x+0.7f*h, tail_pos.y+v*0.7f, 0);
        
        Vector3 tmp = Vector3.zero;

        for (int j = 1; j < count; j++)
        {
            tmp = tail[j].transform.position;
            tail[j].transform.position = tail_pos;
            tail_pos = tmp;
        }
    }

    void Update()
    {
        curTimeout += Time.deltaTime;
        if (curTimeout > timeoutMove)
        {
            curTimeout = 0;
            Move(tailCount);
        }

        if (t_Count != tailCount)
        {
            GameObject clone = Instantiate(_tail) as GameObject;
            clone.name = "Tail_" + tail.Count;
            clone.transform.position = tail_last;
            tail.Add(clone);
        }
        t_Count = tailCount;

        if (Input.GetKeyDown(left)&&(h==0)||Input.GetKeyDown(KeyCode.LeftArrow) && (h == 0))
        {
            h = -shift;
            v = 0;
        }
        else if (Input.GetKeyDown(right) && (h == 0) || Input.GetKeyDown(KeyCode.RightArrow) && (h == 0))
        {
            h = shift;
            v = 0;
        }
        else if (Input.GetKeyDown(down) && (v == 0) || Input.GetKeyDown(KeyCode.DownArrow) && (v == 0))
        {
            v = -shift;
            h = 0;
        }
        else if (Input.GetKeyDown(up) && (v == 0) || Input.GetKeyDown(KeyCode.UpArrow) && (v == 0))
        {
            v = shift;
            h = 0;
        }

        if (lose)
        {
            Debug.Log("Вы проиграли!");
            enabled = false;
        }
        Loss();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            Debug.Log(1);
            lose = true;
            //tail.Clear();   
        }
    }


    public void Loss()
    {
        if (lose == true)
        {
            animator.SetTrigger("boom");
            sound.gameObject.SetActive(false);
            for (int i = 0; i < tailCount; i++)
            {
                tail[i].GetComponent<Animator>().SetTrigger("boom");
                Destroy(tail[i].gameObject, 1);
            }
            menu_create = true;
            text.gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            audio.Play();
            text.text = "Score: " + tailCount;
            tailCount++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            lose = true;
            Debug.Log(2);
        }
  
    }
}
