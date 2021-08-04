using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBonus : MonoBehaviour
{
    public Transform[] BonusPlace;
    public GameObject bonus;
    public float timebonus = 5f;
    public float d = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        d += Time.deltaTime;
        if (d >= timebonus)
        {
            Instantiate(bonus, BonusPlace[Random.Range(0, BonusPlace.Length)].transform.position,Quaternion.identity);
            d = 0;
        }
    }
}
