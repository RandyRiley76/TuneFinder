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

    public void makeSelected()
    {
        gameObject.GetComponent<Renderer>().material = colorMaterial[chosenSelectorNumber];
        gameObject.transform.localScale += toScale;
    }
    public void makeDeselected()
    {
        gameObject.GetComponent<Renderer>().material = color2Material[chosenSelectorNumber];
        gameObject.transform.localScale -= toScale;
    }
    private void OnMouseEnter()
    {
        makeSelected();
    }
    private void OnMouseExit()
    {
        makeDeselected();
    }
    void OnMouseDown()
    {
        playerAudio.PlayOneShot(notes[chosenSelectorNumber], 1f);
        
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
