using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Sprite[] sprite;
    public int i = 0;
    public float smenasprite= 1f;
    public float d = 0;
    public Snake snake;
    public Transform[] waypoints;
    public int cur = 0;
    public float speed = 0.3f;

    //private Animator anim;
    void Start()
    {
        //anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (snake.lose==false) {
            d += Time.deltaTime;
            if (d >= smenasprite)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[i];
                i++;
                d = 0;
            }
            //anim.SetTrigger("idle");
            if (transform.position != waypoints[cur].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[cur].transform.position, speed * Time.deltaTime);

            }
            else cur = cur + 1;
            if (cur == waypoints.Length)
            {
                Debug.Log(1);
                cur = 0;
            }
            if (i == 4)
            {
                i = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            snake.lose = true;
                //Destroy(collision.gameObject);
    }
}
