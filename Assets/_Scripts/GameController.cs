using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//Private Instance Variables
	private int _livesValue = 100;
	private int score = 0;

	//Public Instance Variables
	[Header("Labels")]
	public Text livesLabel;
	public Text scoreLabel;
	public Text gameOverLabel;
	public Text finalLabel;
	public Text victory;
	public Button restartButton;

	[Header("Game Objects")]
	public GameObject Dementor;
	public GameObject Beans;
	public GameObject Player;
	public GameObject tree1;
	public GameObject tree2;

	[Header("Music")]
	public AudioSource endMusic;
	//public AudioSource backgroundMusic;

	//Public Properties

	public int scoreValue // updates score
	{
		get { return this.score; }
		set
		{
			this.score = value;
			this.scoreLabel.text = "Score: " + this.score;
		}
	}

	public int livesValue //updates lives
	{
		get { return this._livesValue; }
		set
		{
			this._livesValue = value;
			this.livesLabel.text = "Health: " + this._livesValue;
		}
	}

	// Use this for initialization
	void Start () {
		//this._livesValue = 100;
		//this.score = 0;
		this.Dementor.SetActive(true);
		this.gameOverLabel.gameObject.SetActive(false);
		this.restartButton.gameObject.SetActive (false);
		this.victory.gameObject.SetActive (false);
		this.finalLabel.gameObject.SetActive (false);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}    

	public void endGame()
	{
		this.scoreLabel.gameObject.SetActive(false);
		this.livesLabel.gameObject.SetActive(false);
		this.gameOverLabel.gameObject.SetActive(true);
		this.finalLabel.gameObject.SetActive(true);
		this.finalLabel.text = "Score: " + this.score;
		this.restartButton.gameObject.SetActive(true);
		this.Dementor.SetActive(false);
		this.Beans.SetActive(false);
		this.Player.SetActive(false);
		endMusic.Play();
		endMusic.loop = true;
	}
	public void endGameVictory(){
		this.scoreLabel.gameObject.SetActive(false);
		this.livesLabel.gameObject.SetActive(false);
		this.victory.gameObject.SetActive(true);
		this.finalLabel.gameObject.SetActive(true);
		this.finalLabel.text = "Score: " + this.score;
		this.restartButton.gameObject.SetActive(true);
		this.Dementor.SetActive(false);
		this.Beans.SetActive(false);
		this.Player.SetActive(false);
		endMusic.Play();
		endMusic.loop = true;
	}

	public void restart_click()
	{
		SceneManager.LoadScene("Main");
	}
}
