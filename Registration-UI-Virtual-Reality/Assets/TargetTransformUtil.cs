using UnityEngine;

public class TargetTransformUtil : MonoBehaviour
{
    public TaskManager tm;

    private void OnEnable()
    {
        TaskManager.BeginningOfSessionEvent += ParentNewTarget;
        TaskManager.TaskUpdateEvent += ParentNewTarget;
    }

    private void OnDisable()
    {
        TaskManager.BeginningOfSessionEvent -= ParentNewTarget;
        TaskManager.TaskUpdateEvent-= ParentNewTarget;
    }

    void ParentNewTarget()
    {
        tm.currentTarget.transform.parent = this.transform;
    }
}
