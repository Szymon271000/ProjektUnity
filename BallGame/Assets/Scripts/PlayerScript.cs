using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private float playerSpeed = 800;
    private float directionSpeed = 20;
    public AudioClip score;
    public AudioClip error;
    public Button audioButton;
    public Sprite audioOn;
    public Sprite audioOff;
    bool audioIsOn;
    bool gameIsOn;
    public Button pauseButton;
    public Sprite gameOn;
    public Sprite gameOff;
    public GameObject pausePanel;
    public GameObject startPanel;
    public GameObject gameLabels;
    public GameObject gameOverPanel;
    public Text scoreText;



    // Start is called before the first frame update
    void Start()
    {
        audioIsOn = true;
        audioButton.GetComponent<Image>().sprite = audioOn;
        gameIsOn = false;
        pausePanel.SetActive(false);
        startPanel.SetActive(true);
        gameLabels.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log("Input: " + moveHorizontal);
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 3f), gameObject.transform.position.y, gameObject.transform.position.z), directionSpeed * Time.fixedDeltaTime);
        if (gameIsOn)
        {
            GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.fixedDeltaTime;
        }
        
    }

    public void StartGame()
    {
        gameIsOn = true;

        startPanel.GetComponent<Animator>().Play("StartAnimation");

        gameLabels.SetActive(true);

        GetComponent<AudioSource>().Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            GetComponent<AudioSource>().PlayOneShot(score, 1.0f);
        }

        else if (other.gameObject.tag == "Pyramid")
        {
            GameOver();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void GameOver()
    {
        GetComponent<AudioSource>().PlayOneShot(error, 1.0f);
        gameOverPanel.SetActive(true);
        gameLabels.SetActive(false);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        gameIsOn = false;
        
        GetComponent<AudioSource>().Stop();

        scoreText.text = ScoreScript.current.score.ToString();

        ScoreScript.current.CheckHighScore();
    }

    public void StopMusic()
    {
        if (audioIsOn)
        {
            GetComponent<AudioSource>().Stop();
            audioIsOn = false;
            audioButton.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            GetComponent<AudioSource>().Play();
            audioIsOn = true;
            audioButton.GetComponent<Image>().sprite = audioOn;
        }
    }
    public void PauseGame()
    {
        if (gameIsOn)
        {
            pausePanel.SetActive(true);
            gameLabels.SetActive(false);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            gameIsOn = false;
            pauseButton.GetComponent<Image>().sprite = gameOff;

            GetComponent<AudioSource>().Pause();
        }
        else
        {
            pausePanel.SetActive(false);
            gameLabels.SetActive(true);
            Invoke("RestartPlayer", 0.5f);
            gameIsOn = true;
            pauseButton.GetComponent<Image>().sprite = gameOn;

            GetComponent<AudioSource>().Play();
        }
    }

    void RestartPlayer()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }
}
//