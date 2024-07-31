using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractGuide : MonoBehaviour
{
    [SerializeField] private RectTransform guideTransform;
    private Vector3 targetPosition;

    private void Start()
    {
        OffGuide();
    }

    private void Update()
    {
        guideTransform.position = 
            Camera.main.WorldToScreenPoint(targetPosition); ;
    }

    public void OnGuide(Vector3 _position)
    {
        targetPosition = _position;
        guideTransform.gameObject.SetActive(true);
    }
    public void OffGuide()
    {
        guideTransform.gameObject.SetActive(false);
    }
}
