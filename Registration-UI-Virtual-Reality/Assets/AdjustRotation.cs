using UnityEngine;
using UnityEngine.UI;

public class AdjustRotation : MonoBehaviour
{
    public TaskManager tm;
    public Slider[] sliders = new Slider[3];
    public GameObject currentSliver;
    public Button resetRot;
    // Start is called before the first frame update


    private void OnEnable()
    {
        TaskManager.TaskUpdateEvent += AdjustEventHandler;
        TaskManager.BeginningOfSessionEvent += AdjustEventHandler;
    }

    private void OnDisable()
    {
        TaskManager.TaskUpdateEvent -= AdjustEventHandler;
        TaskManager.BeginningOfSessionEvent -= AdjustEventHandler;
    }

    void AdjustEventHandler()
    {
        currentSliver = tm.currentSliver;

        foreach (var item in sliders)
        {
            item.onValueChanged.AddListener(delegate
            {
                SetRotation(currentSliver, sliders[0].value, sliders[1].value, sliders[2].value);
                //switch (System.Array.IndexOf(sliders, item))
                //{
                //    case 0:
                //        currentSliver.rotation = Quaternion.Euler(item.value, currentSliver.rotation.y, currentSliver.rotation.z);
                //        break;
                //    case 1:
                //        currentSliver.rotation = Quaternion.Euler(currentSliver.rotation.x, item.value, currentSliver.rotation.z);
                //        break;
                //    case 2:
                //        currentSliver.rotation = Quaternion.Euler(currentSliver.rotation.x, currentSliver.rotation.y, item.value);
                //        break;
                //    default:
                //        break;
                //}
            });
        }
    }

    void SetRotation(GameObject go, float xRot, float yRot, float zRot)
    {
        
        go.transform.rotation = Quaternion.Euler(
            new Vector3(
                xRot,
                yRot,
                zRot
                ));
    }

    public void ResetRotation()
    {
        SetRotation(currentSliver, sliders[0].value, sliders[0].value, sliders[0].value);
        foreach (var item in sliders)
        {
            item.value = 0f;
        }
        
    }

    public void ResetPosition()
    {
        currentSliver.transform.position = tm.sliverStartPos.position;
       
    }

    

}
