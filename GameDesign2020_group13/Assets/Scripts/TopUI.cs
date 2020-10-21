using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopUI : MonoBehaviour
{
    int pig = 0;

    public Image imgPig1;
    public Image imgPig2;
    public Image imgPig3;

    void Start() //Lets start by getting a reference to our image component.
    {
        //GameObject is a class, if you want a reference to the gameobject the script is attached to, you use 'gameObject'

        /*GameObject go = GameObject;
        imgPig1 = go.GetComponent<Image>();
        imgPig2 = go.GetComponent<Image>();
        imgPig3 = go.GetComponent<Image>();
        Pig1();*/
        Pig1();
    }

    public void ChangePig() 
    {
        if( pig == 1)
        {
            Pig2();
        }
        else if (pig == 2)
        {
            Pig3();
        }
        else
        {
            pig = 0;
            Pig1();
        }
    }
    public void Pig1()
    {
        imgPig1.enabled =true;
        imgPig2.enabled = false;
        imgPig3.enabled = false;
    }
    public void Pig2()
    {
        imgPig1.enabled = false;
        imgPig2.enabled = true;
        imgPig3.enabled = false;
    }
    public void Pig3()
    {
        imgPig1.enabled = false;
        imgPig2.enabled = false;
        imgPig3.enabled = true;
    }
   
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pig += 1;
            ChangePig();
        }   
    }
}
