using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ES_StateCheck : MonoBehaviour
{
    public GameObject start_button;
    public GameObject music_on_button;
    public GameObject music_off_button;

    private int current_active;
    private int last_active;

    void Start()
    {
        current_active = 0;
        ChangeActive();
        last_active = current_active;
    }

    void Update()
    {
        if (last_active != current_active)
        {
            ChangeActive();
            Debug.Log("State Changed");
        }
    }

    private void ChangeActive()
    {
        if (current_active == 0)
        {
            EventSystem.current.SetSelectedGameObject(start_button);
            Debug.Log("State 0");
        }
        else if (current_active == 1)
        {
            EventSystem.current.SetSelectedGameObject(music_on_button);
            Debug.Log("State 1");
        }
        else if (current_active == 2)
        {
            EventSystem.current.SetSelectedGameObject(music_off_button);
            Debug.Log("State 2");
        }
        else if (current_active == 3)
        {
            if (music_on_button.active == true)
            {
                EventSystem.current.SetSelectedGameObject(music_on_button);
                last_active = 1;
                Debug.Log("State 1");
            }
            if (music_off_button.active == true)
            {
                EventSystem.current.SetSelectedGameObject(music_off_button);
                last_active = 2;
                Debug.Log("State 2");
            }
        }
        else
        {
            Debug.Log("State 5");
        }

        last_active = current_active;
    }

    public void SetCurrent(int current)
    {
        current_active = current;
    }
}
