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




    void OnMouseDown()
    {
        playerAudio.PlayOneShot(notes[chosenSelectorNumber], 1f);
        Debug.Log(chosenSelectorNumber);
        //gameObject.GetComponent<Renderer>().material = colorMaterial;
        
    }

    private void Awake()
    {
        chosenSelectorNumber = GameManager.Instance.currentSpawn;
    }






    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        //SETS COLOR MATERIAL
        gameObject.GetComponent<Renderer>().material = colorMaterial[chosenSelectorNumber];
        //Debug.Log();
    }

}
