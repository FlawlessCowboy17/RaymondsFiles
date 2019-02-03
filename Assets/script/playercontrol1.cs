using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontrol1 : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text livesText;
    public Text winText;
    public Text loseText;

    private Rigidbody rb;
    private int count;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetcountText();
        lives = 3;
        SetlivesText();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetcountText();
        if(count == 12)
            {
                teleport();
            }
        }
        else if(other.gameObject.CompareTag("bad up"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetcountText();
            lives = lives - 1;
            SetlivesText();
            if (lives <= 0)
            {
                DestroyGameObject();
            }
        }
    }
    void SetcountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20) {
            winText.text = "You win!";
                }
    }
    void SetlivesText()
    {
        livesText.text = "Lives: " + lives.ToString() + "/3";
        if (lives <= 0) {
            loseText.text = "You lose!";
        }
    }
    void teleport()
    {
        transform.position = new Vector3(100, 1.5f, 14);
    }
    void DestroyGameObject()
    {
        gameObject.SetActive(false);
    }
}