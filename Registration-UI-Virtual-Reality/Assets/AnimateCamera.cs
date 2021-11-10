using UnityEngine;
using UnityEngine.UI;

public class AnimateCamera : MonoBehaviour
{
    public Toggle toggleSwitch;
    Animator anim;

    // Start is called before the first frame update
    void Start()

    {
        anim = this.GetComponent<Animator>();
        toggleSwitch.onValueChanged.AddListener(delegate
        {
            if (!toggleSwitch.isOn)
            {
                anim.SetTrigger("FrontToSide");
            }
            else
            {
                anim.SetTrigger("SideToFront");
            }

        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
