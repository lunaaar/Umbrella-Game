using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLoadSaveText : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        TextMeshProUGUI myText = gameObject.GetComponent<TextMeshProUGUI>();
        SaveData save = SaveSystem.LoadSlot();

        switch (save.level)
        {
            case 0:
                myText.text = "LOAD SAVE";
                break;
            case 1:
                myText.text = "LOAD SAVE - 1";
                break;
            case 2:
                myText.text = "LOAD SAVE - 2";
                break;

            default:
                Debug.Log("Error with updating load text");
                break;



        }

       
    }

}
