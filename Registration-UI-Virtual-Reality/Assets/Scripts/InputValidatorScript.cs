using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputValidatorScript : MonoBehaviour
{
    [SerializeField]
    Canvas ca;
    [SerializeField]
    InputField firstName;
    [SerializeField]
    InputField lastName;
    [SerializeField]
    Toggle organ;
    [SerializeField]
    Button nextBtn;
    [SerializeField]
    InputField width;
    [SerializeField]
    InputField height;
    [SerializeField]
    InputField depth;

    public bool isCheckInValid = false;
    public bool isFirstNameValid = false;
    public bool isLastNameValid = false;
    public bool isOrganSelected = false;
    //public bool isWidthValid = false;

    public delegate void InvalidCheck(string field, bool isInputValid);
    public static event InvalidCheck InvalidCheckEvent;

    // Start is called before the first frame update
    void Start()
    {
        firstName.onEndEdit.AddListener(
            delegate {
                isFirstNameValid = CheckInput(firstName);
                if (!isFirstNameValid)
                {
                    //Debug.Log("first name invalid");
                    if (InvalidCheckEvent != null)
                    {
                        InvalidCheckEvent("First Name", isFirstNameValid);
                    }
                }
                CheckOverallValidity();
                if (isCheckInValid)
                {
                    nextBtn.interactable = true;
                }
                SetButtonInteractvity();
            });
        lastName.onEndEdit.AddListener(
            delegate {
                isLastNameValid = CheckInput(lastName);
                if (!isLastNameValid)
                {
                    //Debug.Log("first name invalid");
                    if (InvalidCheckEvent != null)
                    {
                        InvalidCheckEvent("Last Name", isLastNameValid);
                    }
                }
                CheckOverallValidity();
                if (isCheckInValid)
                {
                    nextBtn.interactable = true;
                }
                SetButtonInteractvity();
            });
        organ.onValueChanged.AddListener(
            delegate {
                isOrganSelected = CheckInput(organ);
                CheckOverallValidity();
                SetButtonInteractvity();
            });

        width.onEndEdit.AddListener(
            delegate {
                bool isWidthValid = CheckInput(width, true);
                if (!isWidthValid)
                {
                    if (InvalidCheckEvent != null)
                    {
                        InvalidCheckEvent("width", isWidthValid);
                    }
                }
            });

    }

    bool CheckInput(InputField input) {
        return input.text != "";
    }

    bool CheckInput(InputField input, bool isNumericField) {
        bool result = false;
        float value;
        if (float.TryParse(input.text, out value)) result = true;
        //Debug.Log(result);
        return result;
    }

    bool CheckInput(Toggle t) {
        return t.isOn;
    }

    void CheckOverallValidity() {
        isCheckInValid = (isFirstNameValid && isLastNameValid && isOrganSelected);
    }

    void SetButtonInteractvity() {
        nextBtn.interactable = isCheckInValid;
    }
}
