using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls : MonoBehaviour
{
    enum State{
        SNIPING,
        SHOOTING,
        IDLE
    }

    State state = State.SNIPING;

    public float sensitivity = 10;
    Transform slider = null;
    Animation my_animation = null;

    float force = 0;
    // Start is called before the first frame update
    void Start()
    {
        slider = transform.GetChild(0).GetChild(0);
        my_animation = transform.GetChild(1).GetComponent<Animation>();
    }

    void ChangeState(State s)
    {
        state = s;
        switch (state)
        {
            case State.SNIPING:
                Sniping();
                break;
            case State.SHOOTING:
                my_animation.Play();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.SNIPING:
                Sniping();
                break;
            case State.SHOOTING:
                Shooting();
                break;
            default:
                break;
        }
    }

    void Shooting()
    {
        if (!my_animation.IsPlaying("PeroAnim"))
        {
            //la il faut tirer
            print("skdfksjfk");
        }
    }


    void Sniping()
    {
        if (Input.GetMouseButton(0))
        {
            force += Time.deltaTime;
            if (force > 1)
            {
                force = 1;
                ChangeState(State.SHOOTING);
            }
            slider.GetComponent<Slider>().value = force;
        }
        else
        {
            if(force > 0)
            {
                ChangeState(State.SHOOTING);
            }
        }
        float rotateHorizontal = Input.GetAxis("Mouse X");
        transform.RotateAround(transform.position, -Vector3.up, rotateHorizontal * sensitivity);
    }

}