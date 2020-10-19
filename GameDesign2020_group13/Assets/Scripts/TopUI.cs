using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.SceneManager;

public class TopUI : MonoBehaviour
{
    int pig = 0;
    void ChangePig()
    {
        if (pig == 0)
        {
            Pig1();
            pig++;
        }
        else if( pig == 1)
        {
            Pig2();
            pig++;
        }
        else if (pig == 2)
        {
            Pig3();
            pig++;
        }
        else
        {
            pig = 0;
        }
    }
    void Pig1()
    {
        //Image Pig veranderen ofzo en de andere 2 niet
    }
    void Pig2()
    {

    }
    void Pig3()
    {

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangePig();
        }
    }
}
