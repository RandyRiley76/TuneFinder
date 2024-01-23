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

    public int currentSpawn = 0;
    private GameObject thisSphere;






    // Start is called before the first frame update
    void Start()
    {
        
        
     
        var rot = gameObject.transform.localRotation.eulerAngles; //get the angles
        for (var i=0; i < 5; i++) { 
        rot.Set(0f, i*72f, 0f); //set the angle of new spawn
       
         thisSphere = Instantiate(selectionSphere, new Vector3(0, 0, 0), Quaternion.Euler(rot));
            //thisSphere.transform.localPosition += new Vector3(1, 0, 0);
            thisSphere.transform.Translate(transform.forward);
            
            currentSpawn++;//USED IN SELECTION MANAGER
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
