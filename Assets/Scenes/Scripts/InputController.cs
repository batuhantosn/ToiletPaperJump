using UnityEngine;
using UnityEngine.EventSystems;

//OnPointerDown tıkladıgım vakit
//OnPointerUp tıkladıgımda elimi kaldırdıgımda
//OnBeginDrag sürüklemeye başladıgım
//OnDrag sürüklediğim zaman
public class InputController : MonoBehaviour,IDragHandler,IBeginDragHandler
{
    [SerializeField] private Transform cylinderTransform;
    [SerializeField] private float speed;
    [SerializeField] private GameObject swipeText;
    [SerializeField] private Rigidbody ball;



    public void OnDrag(PointerEventData eventData)
    {
        var rotation = cylinderTransform.rotation;
        var current = rotation.eulerAngles.y;
        current += -eventData.delta.x * speed;
        rotation.eulerAngles = new Vector3(0,current,0);

        cylinderTransform.rotation = rotation;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        swipeText.SetActive(false);
        ball.useGravity = true;
    }
}
