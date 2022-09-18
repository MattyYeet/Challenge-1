using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text livesText;

    public Text winText;

    private Rigidbody rb;
    private int count;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        SetCountText ();
        SetLivesText ();
        winText.text = "";
    }

    void Update()
    {
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHori, 0.0f, moveVert);

        rb.AddForce(movement * speed);
        if (count == 16 || lives == 0)
        {
            rb.isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
            Teleport ();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetLivesText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 16)
        {
            winText.text = "You Win! This game was \ncreated by Matthew Neet";
        }
    }

    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString();
        if(lives == 0)
        {
            gameObject.SetActive(false);
            winText.text = "You Lose, better luck next time! \nThis game was \ncreated by Matthew Neet";
        }
    }

    void Teleport ()
    {
        if (count == 8)
        {
            rb.transform.position = new Vector3(-45.0f, 0.5f, 0.0f);
        }
    }
}