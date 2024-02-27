using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        Main.Instance.SetCursor(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Main.Instance.SetCursor(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Main.Instance.PlayClickAudio();
    }
}
