using UnityEngine.EventSystems;
using UnityEngine;

public class JoybuttonController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool pressed { private set; get; }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
