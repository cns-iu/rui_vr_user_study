using UnityEngine;

public class ShowScreenAtEnd : MonoBehaviour
{

    public GameObject EndScreen;

    private void OnEnable()
    {
        TaskManager.EndOfSessionEvent += ShowScreen;
    }

    private void OnDisable()
    {
        TaskManager.EndOfSessionEvent -= ShowScreen;
    }

    void ShowScreen()
    {
        EndScreen.SetActive(true);
    }
}
