using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleButton : MonoBehaviour
{

    public Material matHighlight;
    public Material matDull;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(StartRoundReady());
        gameObject.GetComponent<Renderer>().material = matHighlight;
    }

    public  IEnumerable StartRoundReady()
    {
        yield return new WaitForSecondsRealtime(.3f);
        gameObject.GetComponent<Renderer>().material = matHighlight;
        yield return new WaitForSecondsRealtime(.3f);
        gameObject.GetComponent<Renderer>().material = matDull;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        //Debug.Log("Button Pressed");
        if (GameManager.Instance.playerTurn == false)
        {
            StartCoroutine(GameManager.Instance.ShowSequenceAddOne());
        }
    }
}
