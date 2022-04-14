using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateSlot2Text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        TextMeshProUGUI myText = gameObject.GetComponent<TextMeshProUGUI>();
        SaveData save = SaveSystem.load2();

        switch (save.level)
        {
            case 0:
                myText.text = "LOAD SAVE";
                break;
            case 1:
                myText.text = "Level: 1\n";
                break;
            case 2:
                myText.text = "Level: 2\n";
                break;
            case 3:
                myText.text = "Level: 3\n";
                break;
            case 4:
                myText.text = "Level: 4\n";
                break;
            case 5:
                myText.text = "Level: 5\n";
                break;
            case 6:
                myText.text = "Level: 6\n";
                break;
            case 7:
                myText.text = "Level: 7\n";
                break;
            case 8:
                myText.text = "Level: 8\n";
                break;
            case 9:
                myText.text = "Level: 9\n";
                break;
            case 10:
                myText.text = "Level: 10\n";
                break;
            case 11:
                myText.text = "Level: 11\n";
                break;
            default:
                Debug.Log("Error with updating load text");
                break;

        }

        myText.text = myText.text + save.date;


    }

}
