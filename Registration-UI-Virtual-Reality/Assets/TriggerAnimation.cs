using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public float smoothing;
    public float speedPerFrame;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        float speed = speedPerFrame * Time.deltaTime * smoothing;

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.enabled = !anim.enabled;
            Debug.Log("isAnimEnabled: " + anim.enabled);
        }
        anim.SetBool("startAnimation", Input.GetKeyDown(KeyCode.F));
        //KeyCode pressed = Event.current.keyCode;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, speed, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -speed, 0f);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(-speed, 0f, 0f);
        }
    }
}
