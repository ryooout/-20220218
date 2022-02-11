using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    float x;
    float z;
    int life = 3;
    Animator animator;
    Rigidbody rb;
    public Text lifeText;
    public Text clearText;
    public Text goalText;
    public RawImage gameOverText;
    public Button nextStageButton;
    bool isGoal;
    public Text timeText;
    float time;
    public int speed = 2;
    public Vector3 acceleration;
    void Start()
    {
        isGoal = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        lifeText.text = "Life:" + life.ToString();
        timeText.text = "時間:" + life.ToString("F1");
        clearText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        nextStageButton.gameObject.SetActive(false);
        goalText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        Vector3 direction = transform.position + new Vector3(x, 0, z).normalized * speed;
        transform.LookAt(direction);
        rb.velocity = new Vector3(x, 0, z).normalized * speed;
        rb.AddForce(acceleration, ForceMode.Acceleration);
        animator.SetFloat("Speed", rb.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
        if (!isGoal)
        {
            time += Time.deltaTime;
        }
        timeText.text = "記録:" + time.ToString("F1") + "秒";

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Goal")
        {
            clearText.gameObject.SetActive(true);
            nextStageButton.gameObject.SetActive(true);
            isGoal = true;
            rb.isKinematic = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        Damage damage = other.GetComponent<Damage>();
        if (other.CompareTag("Enemy") && damage != null)
        {

            Debug.Log("敵からダメージを受けた");
        }
        if (life == 0)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == ("Death"))
        {
            gameOverText.gameObject.SetActive(true);
            goalText.gameObject.SetActive(false);
            isGoal = true;
            rb.isKinematic = true;
        }

    }
}



