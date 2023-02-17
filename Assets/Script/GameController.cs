using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script requires the GameObject to have a Prefabs class component
[RequireComponent(typeof(Prefabs))]
public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    [SerializeField]
    private int countKnife;
    [Header("Knife Spawning")]
    [SerializeField]
    private Vector3 positionKnife;
    [SerializeField]
    private GameObject knife;

    public Prefabs GameUI { get; private set; }

    private void Awake()
    {
        instance = this;
        GameUI = GetComponent<Prefabs>();
    }

    private void Start()
    {
        GameUI.SetKnifeCountDisplay(countKnife);
    }

    // Game Over
    public void hitKnife()
    {
        if (countKnife > 0)
        {
            spawnKnife();
        }
        else
        {
            Audio.assign.playSound("point", 4f);
            loseGame(true);
        }
    }

    private void spawnKnife()
    {
        countKnife--;
        // Born another knife
        Instantiate(knife, positionKnife, Quaternion.identity);
    }
    public void loseGame(bool win)
    {
        StartCoroutine("GameOver", win);
    }

    // Loser interface
    private IEnumerator GameOver(bool win)
    {
        if (win)
        {
            // If not press the "Restart" button after 3 seconds to reload automatically
            GameUI.showRestart();
            yield return new WaitForSecondsRealtime(3f);
            restartGame();
            // Or Invoke("restartGame", 3);
        }
    }
    
    public void restartGame()
    {
        // Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        // Or SceneManager.LoadScene("_KnifeHit");
    }
}
