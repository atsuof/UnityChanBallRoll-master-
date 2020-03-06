using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalChecker : MonoBehaviour
{
    public GameObject unityChan;
    public AudioSource gameBGM;
    public AudioSource goalBGM;
    public GameObject retryBtn;

    // Start is called before the first frame update
    void Start()
    {
        retryBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        gameBGM.Stop();
        goalBGM.Play();
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        unityChan.transform.LookAt(Camera.main.transform);
        unityChan.GetComponent<Animator>().SetTrigger("Goal");
        retryBtn.SetActive(true);
    }

    public void RetryStatge()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}