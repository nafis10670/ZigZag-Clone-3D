using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    private Rigidbody rb;
    private bool walkingRight = true;
    public float walkingSpeed = 2f;
    public float speedIncrease = 0.02f;

    public Transform rayStart;
    private Animator animator;

    private GameManager gameManager;

    public GameObject crystalEffect;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    [ContextMenu("AddForce")]
    public void AddForce()
    {
        rb.AddForce(new Vector3(-1f, 0, 0), ForceMode.VelocityChange);
    }
    /*private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name== "Cube")
        {
            print("INSIDE");
        }
        //print("INSIDE" + collision.transform.name);

    }*/
    public void MoveCharacter()
    {
        rb.transform.position = transform.position + transform.forward * (walkingSpeed * Time.deltaTime);
        this.walkingSpeed += Time.deltaTime * this.speedIncrease;
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
            return;
        else
            animator.SetTrigger("hasGameStarted");

        MoveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeDirection();

        if(!Physics.Raycast(this.rayStart.position, -transform.up, out var hit, Mathf.Infinity))
        {
            animator.SetTrigger("isJumping");
            animator.SetTrigger("isFalling");
        }
        else
        {
            animator.SetTrigger("notFallingAnymore");
        }

        if (transform.position.y <= -4)
            gameManager.EndGame();
    }

    public void ChangeDirection()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }

        walkingRight = !walkingRight;

        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Coin"))
        {
            //Destroy(other.gameObject);
            gameManager.IncreaseScore();

            GameObject g = Instantiate(crystalEffect, other.transform.position, Quaternion.identity);
            Destroy(g, 1);
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
