using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTriggerScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GetScore();
    }
}
