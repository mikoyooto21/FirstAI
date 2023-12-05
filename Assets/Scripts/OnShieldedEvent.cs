using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ButtonLongPressListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    
    [SerializeField]
    private Material currentColor;

    [SerializeField]
    private Material originalColor;

    [SerializeField]
    private Material shieldedColor;
    
    private bool isPointerDown = false;
    private bool isMaxPressed = false;
    private float pressTime;

    private void Awake()
    {
        button = GetComponent<Button>();
        currentColor = FindFirstObjectByType<PlayerMovementNM>().gameObject.GetComponent<MeshRenderer>().material;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("StartDown");
        isMaxPressed = false;
        isPointerDown = true;
        currentColor = shieldedColor;
        pressTime = Time.time;
        StartCoroutine(Timer());
        Debug.Log("EndDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("StartUp");
        currentColor = originalColor;
        StartCoroutine(DisableButtonForSeconds(2f));
        Debug.Log("EndUp");
    }

     private IEnumerator Timer()
    {
        Debug.Log("StartT");
        while (isPointerDown && !isMaxPressed)
        {
        Switchers.shielded = true;
            Debug.Log("StartTW");
            if (Time.time - pressTime >= 2f)
            {
                Debug.Log("StartTF");
                isPointerDown = false;
                isMaxPressed = true;
                button.interactable = false;
                
                Switchers.shielded = false;
                Debug.Log("EndTF");
                yield break;
            }
            Debug.Log("EndTW");
            StopCoroutine(Timer());
            yield return null;
        }
        Debug.Log("EndT");
    }

    private IEnumerator DisableButtonForSeconds(float seconds)
    {
        Debug.Log("StartD");
        button.interactable = false;
        yield return new WaitForSeconds(seconds);
        button.interactable = true;
        Debug.Log("EndD");
    }
}
