using UnityEngine;
using UnityEngine.EventSystems;

public class TaskButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject taskListPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        taskListPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        taskListPanel.SetActive(false);
    }
}