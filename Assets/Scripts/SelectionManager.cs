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

    private Vector3 toScale = new Vector3(0.5f, 0.5f, 0.5f);

    private void OnMouseEnter()
    {
        //  gameObject.GetComponent<Renderer>().material = colorMaterial;
        gameObject.GetComponent<Renderer>().material = colorMaterial[chosenSelectorNumber];
        gameObject.transform.localScale += toScale;
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material = color2Material[chosenSelectorNumber];
        gameObject.transform.localScale -= toScale;
    }
    void OnMouseDown()
    {
        playerAudio.PlayOneShot(notes[chosenSelectorNumber], 1f);
       // Debug.Log(chosenSelectorNumber);
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
        gameObject.GetComponent<Renderer>().material = color2Material[chosenSelectorNumber];
        //Debug.Log();
    }

}
