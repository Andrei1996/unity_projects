using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
    public float jumpHeight;
	public Text countText;
	public Text winText;
    public bool isGrounded;

	private Rigidbody rb;
	private int count;
    private bool dbJump;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();

		count = 0;

		SetCountText ();

		winText.text = "";
	}

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnCollisionExit()
    {
        isGrounded = false;
    }

    void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space pressed");
            if (isGrounded)
            {
                Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
                GetComponent<Rigidbody>().AddForce(jump);
                Debug.Log(isGrounded);
                dbJump = true;
            } else
            {
                if(dbJump)
                {
                    dbJump = false;
                    Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
                    GetComponent<Rigidbody>().AddForce(jump);
                    Debug.Log(isGrounded);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);

			count = count + 1;

			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
}