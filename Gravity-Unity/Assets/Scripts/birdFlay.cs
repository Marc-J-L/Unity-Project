using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class birdFlay : MonoBehaviour
{
    public Rigidbody2D birdbody;

    public Animator animator;

    public GameManager gameManager;

    public float rotateT = 2f;

    public Transform birdImg;

    public float birdSpeed = 5.0f;

    public AudioController audioController;

    void Start()
    {
        animator.SetInteger("state", 1);
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned in birdFlay script.");
            return;
        }

        if (!gameManager.isGameStart)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Fly();
            audioController.PlaySfx(audioController.dash);
        }


        birdImg.transform.DORotateQuaternion(Quaternion.Euler(0, 0, birdbody.velocity.y * rotateT), 0.3f);
    }

    public void Fly()
    {
        birdbody.velocity = new Vector2(0, birdSpeed);
    }

    public void ChangeState(bool isFly,bool isSim = false)
    {
        if (isFly)
        {
            animator.SetInteger("state", 0);
            
        }
        else
        {
            animator.SetInteger("state", 1);
           
        }
        birdbody.simulated = isSim;
    }
}
