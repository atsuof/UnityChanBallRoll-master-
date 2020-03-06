using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0;
    int count;
    public Text countText;
    private AudioSource getBGM;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        getBGM = GetComponent<AudioSource>();
        displayCount();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0, moveV);

        rb.AddForce(move* speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            getBGM.Play();
            other.gameObject.SetActive(false);
            count++;
            displayCount();
        }
        else if (other.gameObject.CompareTag("Bottom"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    private void displayCount()
    {
        countText.text = "Get Count : " + count.ToString();
    }
}
