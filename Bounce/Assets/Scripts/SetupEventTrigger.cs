using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SetupEventTrigger : MonoBehaviour
{
    PlayerController playerController;

    public enum ButtonID { Left, Right, Jump }

    ButtonID buttonID;

    void Start()
    {
        if(gameObject.name == "Button Left")
        {
            buttonID = ButtonID.Left;
        }
        else if (gameObject.name == "Button Right")
        {
            buttonID = ButtonID.Right;
        }
        else if (gameObject.name == "Button Jump")
        {
            buttonID = ButtonID.Jump;
        }

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        EventTrigger trigger = GetComponent<EventTrigger>();

        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);
        }

        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerUp;
            entry.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);
        }
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        switch (buttonID)
        {
            case ButtonID.Left:
                playerController.m_leftButton = true;
                break;
            case ButtonID.Right:
                playerController.m_rightButton = true;
                break;
            case ButtonID.Jump:
                playerController.m_jumpButton = true;
                break;
            default:
                break;
        }
    }

    public void OnPointerUpDelegate(PointerEventData data)
    {
        switch (buttonID)
        {
            case ButtonID.Left:
                playerController.m_leftButton = false;
                break;
            case ButtonID.Right:
                playerController.m_rightButton = false;
                break;
            case ButtonID.Jump:
                playerController.m_jumpButton = false;
                playerController.m_jumpButtonReleased = true;
                break;
            default:
                break;
        }
    }
}
