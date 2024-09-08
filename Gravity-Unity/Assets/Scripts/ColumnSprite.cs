using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSprite : MonoBehaviour
{
    public float columnSpeed = 0.05f;

    public bool canMove = true;

    public void FixedUpdate()
    {
        if (!canMove) return;
        transform.Translate(-columnSpeed, 0, 0);
    }

    public void RandomHeight()
    {
        float r = Random.Range(-1.85f, 2.15f);
        transform.SetPositionAndRotation(new Vector3(transform.position.x, r, transform.position.z), transform.rotation);

    }

     
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }

}
