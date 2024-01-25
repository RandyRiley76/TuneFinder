using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public GameObject selectionSphere;
    public static GameManager Instance;

    public int currentSpawn = 0;
    private GameObject[] thisSphere = new GameObject[5];
    public SelectionManager selectionManager;

    public GameObject middleButton;

   public List<int> notesPlayed = new List<int>();
   public List<int> playerNotesPlayed = new List<int>();
    public bool playerTurn = false;

    public GameObject highScoreText;
    public int highScore =0;
   

    private void Awake()
    {
        //START DATA PERSISTANCE
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //END DATA PERSISTANCE
    }

 


    // Start is called before the first frame update
    void Start()
    {

        //SET UP SELECTION SPHERES
        var rot = gameObject.transform.localRotation.eulerAngles; //get the angles
        for (var i=0; i < 5; i++) { 
        rot.Set(0f, i*72f, 0f); //set the angle of new spawn
         thisSphere[i] = Instantiate(selectionSphere, new Vector3(0, 0, 0), Quaternion.Euler(rot));
         thisSphere[i].transform.Translate(transform.forward);
         currentSpawn++;//USED IN SELECTION MANAGER
        }

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   public IEnumerator CircleDance()
    {


        for (var j = 0; j < 2; j++)
        {
            // for (var i = 0; i < 5; i++)//for accending
            for (var i = 4; i >= 0; i--)//for decending
            {

                thisSphere[i].GetComponent<SelectionManager>().FlashAsSelected();
                yield return new WaitForSecondsRealtime(.2f);
            }
        }
        StartCoroutine(middleButton.GetComponent<MiddleButton>().StartRoundReady());
    }
    public IEnumerator ShowSequenceAddOne()
    {
        yield return new WaitForSecondsRealtime(1f);
        for (var i = 0; i < notesPlayed.Count; i++) {
            thisSphere[notesPlayed[i]].GetComponent<SelectionManager>().FlashAsSelected();
            yield return new WaitForSecondsRealtime(.3f);
        }
        notesPlayed.Add(Random.Range(0, 4));
        // Debug.Log(i);
        var lastInList = notesPlayed[notesPlayed.Count-1];
        thisSphere[lastInList].GetComponent<SelectionManager>().FlashAsSelected();
        playerTurn = true;

    }
    public void CheckIfPlayedRightNote()
    {
        for (var i = 0; i < playerNotesPlayed.Count; i++)
        {
            if (playerNotesPlayed[i] == notesPlayed[i])//Played the right note
            {
                if (playerNotesPlayed.Count > highScore) {
                    highScore = playerNotesPlayed.Count;
                    highScoreText.GetComponent<TextMeshProUGUI>().text = "High Score " + highScore;
                }

                if (playerNotesPlayed.Count == notesPlayed.Count)//START A NEW ROUND IF YOU GOT ALL THE NOTES RIGHT
                {
                    playerNotesPlayed.Clear();
                    playerTurn = false;
                    Debug.Log("NewRound");
                    StartCoroutine(ShowSequenceAddOne());
                }
            }
            else//YOU PLAYED WRONG AND RESET GAME
            {
                StartCoroutine(CircleDance());
                Debug.Log("You didn't play it right");
                playerNotesPlayed.Clear();
                notesPlayed.Clear();
                playerTurn = false;
                
                break;
            }
        }
    }
}
