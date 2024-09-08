using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    public GameObject ColumnPrefab;

    public Transform Columns;

    public GameManager gm;

    public float SpawnTime = 1.6f;

    private List<GameObject> columns = new List<GameObject>();

    public bool ColumnIsMoving = true;

    public void Start()
    {
        StartCoroutine(SpawnColumn());
    }

    public void StartMove()
    {
        ColumnIsMoving = true;
        foreach (GameObject item in columns)
        {
            item.GetComponent<ColumnSprite>().canMove = true;
        }
    }

    public void StopMove()
    {
        ColumnIsMoving = false;
        foreach (GameObject item in columns)
        {
            item.GetComponent<ColumnSprite>().canMove = false;
        }
    }

    public void SpawnOneColumn()
    {
        GameObject column = GameObject.Instantiate(ColumnPrefab,Columns);
        column.GetComponent<ColumnSprite>().RandomHeight();

        columns.Add(column);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //SpawnOneColumn();
            StopMove();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            
            StartMove();
        }
    }

    IEnumerator SpawnColumn()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            if (!gm.isGameStart) continue;
            if (!ColumnIsMoving) continue;
            SpawnOneColumn();
        }
        
    }

}
