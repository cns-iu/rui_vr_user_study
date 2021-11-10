using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputFieldStateHandler : MonoBehaviour
{
    public Sprite active;
    public Sprite inactive;
    public Sprite error;

    public Text placeholder;

    public void SetPlaceHolder(bool isPlaceholderVisible)
    {
        if (!isPlaceholderVisible) placeholder.text = "";
    }

    private void OnEnable()
    {
        InputValidatorScript.InvalidCheckEvent += SwitchToError;
    }

    private void OnDisable()
    {
        InputValidatorScript.InvalidCheckEvent -= SwitchToError;
    }

    public void SwitchToActive() {
        //Debug.Log("active");
        this.GetComponent<Image>().sprite = active;
    }

    public void SwitchToInactive()
    {
        //Debug.Log("inactive");
        if (true)
        {
            this.GetComponent<Image>().sprite = inactive;
        }
       
    }

    public void SwitchToError(string field, bool isInputValid) {
        //Debug.Log(field);
        if (field.Equals(this.gameObject.name))
        {
            //Debug.Log("error detected in " + this.gameObject.name);
            //Debug.Log(this.gameObject.name);
            this.GetComponent<Image>().sprite = error;
            placeholder.text = field;
            //Debug.Log(this.GetComponent<Image>().sprite.name);
        }
    }
}
