using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectionManager : MonoBehaviour
{
    //TO PLAY SOUND CLIPS
    private AudioSource playerAudio;
    public AudioClip[] notes;

    public int chosenSelectorNumber;

   // public Material colorMaterial;
    public Material[] colorMaterial;
    public Material[] color2Material;

    private Vector3 toScaleLarge = new Vector3(1.5f, 1.5f, 1.5f);
    private Vector3 toScaleNormal = new Vector3(1f, 1f, 1f);

    public void makeSelected()
    {
        gameObject.GetComponent<Renderer>().material = colorMaterial[chosenSelectorNumber];
        gameObject.transform.localScale = toScaleLarge;
    }
    public void makeDeselected()
    {
        gameObject.GetComponent<Renderer>().material = color2Material[chosenSelectorNumber];
        gameObject.transform.localScale = toScaleNormal;
    }
    private void OnMouseEnter()
    {
        if (GameManager.Instance.playerTurn)
        {
            makeSelected();
            
        }
    }
    private void OnMouseExit()
    {
        if (GameManager.Instance.playerTurn)
        {
            makeDeselected();
        }
    }
    void OnMouseDown()
    {
        if (GameManager.Instance.playerTurn)
        {
            FlashAsSelected();
            playerAudio.PlayOneShot(notes[chosenSelectorNumber], 1f);//1f is the volume
            GameManager.Instance.playerNotesPlayed.Add(chosenSelectorNumber);
            GameManager.Instance.CheckIfPlayedRightNote();
        }
    }

    private void Awake()
    {
        chosenSelectorNumber = GameManager.Instance.currentSpawn;
        gameObject.GetComponent<Renderer>().material = color2Material[chosenSelectorNumber];//Set to drab colors
    }
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        
    }
   public void FlashAsSelected() {
        makeSelected();
        playerAudio.PlayOneShot(notes[chosenSelectorNumber], 1f);
        Invoke("makeDeselected", .1f);
    }
}
