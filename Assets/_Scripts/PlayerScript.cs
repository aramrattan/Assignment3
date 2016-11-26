using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour {

    //Public Instance Variables
	public GameController gameController;

	[Header("Game Objects")]
    public GameObject Dementor;
    public GameObject Beans;
    public GameObject tree1;
    public GameObject tree2;

    [Header("Music")]

    public AudioSource backgroundMusic;


    [Header("Sounds")]
    public AudioSource beans;
    public AudioSource dementor;


    // Use this for initialization
    void Start()
    {
        backgroundMusic.Play();
        backgroundMusic.loop = true;


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider otherGameObject)
    {
        if (otherGameObject.CompareTag("Beans")) 
        {
            otherGameObject.gameObject.SetActive(false);
			this.gameController.scoreValue += 10;
            this.beans.Play();
			Debug.Log ("B Hit");
        }

        if (otherGameObject.gameObject.name == "Tree") //cheat to transport to other tree
        {
            transform.position = new Vector3(tree2.gameObject.transform.position.x, tree2.gameObject.transform.position.y + 5, tree2.gameObject.transform.position.z - 3);
        }

        if (otherGameObject.gameObject.name == "Tree 1")//cheat to transport back to other tree, but on the top of the maze
        {
            transform.position = new Vector3(tree1.gameObject.transform.position.x, tree1.gameObject.transform.position.y + 5, tree1.gameObject.transform.position.z - 3);
        }

		if (otherGameObject.CompareTag("Enemy")) 
        {
            this.gameController.livesValue -= 5;
			Debug.Log ("D hit");
			this.dementor.Play();

			if (this.gameController.livesValue <= 0)
            {
                this.backgroundMusic.Stop();
                this.backgroundMusic.loop = false;
                this.gameController.endGame();
            }

        }
		if (otherGameObject.CompareTag("Cup")) 
		{

				this.backgroundMusic.Stop();
				this.backgroundMusic.loop = false;
				this.gameController.endGameVictory();
			

		}
    }
		
}
