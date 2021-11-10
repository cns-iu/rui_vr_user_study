using UnityEngine;
using UnityEngine.UI;

public class HandleSubmissionDesktop : MonoBehaviour
{
    private Button btn;

    public delegate void Interact();

    public static event Interact interactEvent;

    // Start is called before the first frame update
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate
        {
            if (interactEvent != null)
            {
                interactEvent();
            }
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (interactEvent != null)
            {
                interactEvent();
            }
        }
    }
}