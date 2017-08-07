using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int score;
    public Text scoreText;
    public Text winText;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        winText.text = "";
        DoShit();
	}

    void DoShit()
    {
        scoreText.text = string.Format("Count: {0}", score);
    }
    // Update is called once per frame
    void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        var spacePressed = Input.GetKeyDown(KeyCode.Space);

        rb.AddForce(movement * speed);
        if (spacePressed)
            rb.AddForce(new Vector3(0f, 500f, 0f));
        if (score >= 15) winText.text = "YOU ARE THE GREATEST";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            DoShit();
        }
        
    }
}
