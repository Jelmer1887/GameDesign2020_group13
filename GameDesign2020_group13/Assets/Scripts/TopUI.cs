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
   
    public Text textPig1;
    public Text textPig2;
    public Text textPig3;
    
    public Image imgHeart1;
    public Image imgHeart2;
    public Image imgHeart3;

    private static int lives;

    void Start() //Lets start by getting a reference to our image component.
    {
        Pig1();
        LivesUpdate(3);
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

        textPig1.enabled = true;
        textPig2.enabled = false;
        textPig3.enabled = false;
    }
    public void Pig2()
    {
        imgPig1.enabled = false;
        imgPig2.enabled = true;
        imgPig3.enabled = false;

        textPig1.enabled = false;
        textPig2.enabled = true;
        textPig3.enabled = false;
    }
    public void Pig3()
    {
        imgPig1.enabled = false;
        imgPig2.enabled = false;
        imgPig3.enabled = true;

        textPig1.enabled = false;
        textPig2.enabled = false;
        textPig3.enabled = true;
    }
    public void LivesUpdate(int life) 
    {
        if (life == 3)
        {
            imgHeart1.enabled = true;
            imgHeart2.enabled = true;
            imgHeart3.enabled = true;
        }else if(life == 2)
        {
            imgHeart1.enabled = true;
            imgHeart2.enabled = true;
            imgHeart3.enabled = false;
        }else if(life == 1)
        {
            imgHeart1.enabled = true;
            imgHeart2.enabled = false;
            imgHeart3.enabled = false;
        }
        else
        {
            imgHeart1.enabled = false;
            imgHeart2.enabled = false;
            imgHeart3.enabled = false;
        }
    }
   
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pig += 1;
            ChangePig();
        }
        lives = GameMaster.lives;
        LivesUpdate(lives);
    }
}
