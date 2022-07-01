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

    private Camera playerCamera;
    private Camera mainCamera;

    State state = State.SNIPING;

    public GameObject projectile;

    public float sensitivity = 10;
    Transform slider = null;
    Animation my_animation = null;
    Transform pivot = null;

    float force = 0;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        slider = transform.GetChild(0).GetChild(0);
        my_animation = transform.GetChild(1).GetComponent<Animation>();
        pivot = transform.GetChild(1);
    }

    void ChangeState(State s)
    {
        state = s;
        switch (state)
        {
            case State.SNIPING:
                force = 0;
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
        if (time > 0f){
            // Subtract the difference of the last time the method has been called
            time -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space )&& time <= 0)
        {
            changeCameraPositionWhenShooting();
            time = 0.2f;
        }

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
        Debug.Log("shoot");
        if (!my_animation.isPlaying)
        {
            //la il faut tirer
            var my_proj = Instantiate(projectile, pivot.GetChild(0).transform.position, pivot.GetChild(0).transform.rotation);
            Vector3 dir = pivot.GetChild(0).transform.rotation.eulerAngles;
            //float temp = dir.x;
            //dir.x = dir.y;
            //dir.y = dir.z;
            //dir.z = temp;
            
            my_proj.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 600 * force);
            ChangeState(State.SNIPING);
            while (my_proj.GetComponent<Rigidbody>().velocity.magnitude > 0.01f)
            {
                Debug.Log("je passe");
                //Block shoot
            }
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

    void changeCameraPositionWhenShooting()
    {
     
        playerCamera = GameObject.Find("Camera").GetComponent<Camera>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        playerCamera.enabled = !playerCamera.enabled;
        mainCamera.enabled = !playerCamera.enabled;

    }

}
