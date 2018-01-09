using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    public Text info;



    public void SetInfo(string message )
    {
        info.text = message;
    }

}
