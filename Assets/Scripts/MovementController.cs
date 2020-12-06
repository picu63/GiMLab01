using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    //private Rigidbody rigidbody;

    public float speed = 500;
    public int points = 0;
    public int winPoints = 10;
    public Vector3 startPosition;
    private Text mainText;
    private Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        mainText = GameObject.FindGameObjectWithTag("MainText").GetComponent<Text>();
        pointsText = GameObject.FindGameObjectWithTag("PointsText").GetComponent<Text>();
        startPosition = gameObject.transform.position;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Return))
        {
            mainText.text = string.Empty;
            pointsText.text = "0";
            gameObject.transform.position = startPosition;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PickUp")
        {
            collider.gameObject.SetActive(false);
            points++;
            pointsText.text = points.ToString();
        }

        if (points >= winPoints)
        {
            mainText.text = "You WIN\nPress Enter to start new game.";
        }
    }
}
