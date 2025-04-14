using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class MyJoystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Image imgBg;
        private Image imgThump;
        private CanvasScaler canvasScale;
        private RectTransform rectParent;
        float deltaX;
        float deltaY;
        [SerializeField] private bool isMoveJoystick;
        [SerializeField] private Vector2 pos;
        public Vector2 posAcceptAction = new Vector2(650f, 300f);

        void Start()
        {
            canvasScale = transform.parent.GetComponent<CanvasScaler>();
            rectParent = transform.parent.GetComponent<RectTransform>();
            imgBg = transform.GetChild(0).GetComponent<Image>();
            imgThump = transform.GetChild(0).GetChild(0).GetComponent<Image>();
            deltaX = (rectParent.sizeDelta.x - canvasScale.referenceResolution.x);
            deltaY = (rectParent.sizeDelta.y - canvasScale.referenceResolution.y);
        }

        //UnityEvent
        [System.Serializable] public class OnMoveStart : UnityEvent { }
        [System.Serializable] public class OnMove : UnityEvent<Vector2> { }
        [System.Serializable] public class OnMoveEnd : UnityEvent { }

        [SerializeField] public OnMoveStart onMoveStart;
        [SerializeField] public OnMove onMove;
        [SerializeField] public OnMoveEnd onMoveEnd;

        public void OnBeginDrag(PointerEventData eventData)
        {

        }
        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(imgBg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
            {
                pos = Vector2.ClampMagnitude(pos, 1.0f);
                imgThump.rectTransform.anchoredPosition = new Vector2(
                      pos.x * (imgBg.rectTransform.sizeDelta.x / 4)
                    , pos.y * (imgBg.rectTransform.sizeDelta.y / 4));
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            onMoveStart.Invoke();
            pos = Vector2.zero;
            isMoveJoystick = true;
            float posXNow = eventData.position.x * canvasScale.referenceResolution.x / Camera.main.pixelWidth;
            float posYNow = eventData.position.y * canvasScale.referenceResolution.y / Camera.main.pixelHeight;

            imgBg.rectTransform.anchoredPosition = new Vector2(
                                    Mathf.Clamp(posXNow + (deltaX / (canvasScale.referenceResolution.x / posXNow)), 0, posAcceptAction.x)
                                   , Mathf.Clamp(posYNow + (deltaY / (canvasScale.referenceResolution.y / posYNow)), 0, posAcceptAction.y));
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            imgThump.rectTransform.localPosition = Vector2.zero;
            isMoveJoystick = false;
            onMoveEnd.Invoke();
        }
        void Update()
        {
            if (isMoveJoystick)
            {
                onMove.Invoke(pos);
            }
        }
#if UNITY_EDITOR
        private void LateUpdate()
        {
            if (!isMoveJoystick)
            {
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    ChangeKeyState(KeyState.upRight);
                    onMove.Invoke(pos);
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                {
                    ChangeKeyState(KeyState.downRight);
                    onMove.Invoke(pos);
                }
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
                {
                    ChangeKeyState(KeyState.upLeft);
                    onMove.Invoke(pos);
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {
                    ChangeKeyState(KeyState.downLeft);
                    onMove.Invoke(pos);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    ChangeKeyState(KeyState.up);
                    onMove.Invoke(pos);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    ChangeKeyState(KeyState.down);
                    onMove.Invoke(pos);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    ChangeKeyState(KeyState.left);
                    onMove.Invoke(pos);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    ChangeKeyState(KeyState.right);
                    onMove.Invoke(pos);
                }
                else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A))
                {
                    ChangeKeyState(KeyState.none);
                    onMoveEnd.Invoke();
                }
                else
                {
                    ChangeKeyState(KeyState.none);
                }
            }
        }
        void ChangeKeyState(KeyState a_keyState)
        {
            keyState = a_keyState;
            switch (keyState)
            {
                case KeyState.upRight:
                    pos = new Vector2(1, 1);
                    break;
                case KeyState.downRight:
                    pos = new Vector2(1, -1);
                    break;
                case KeyState.upLeft:
                    pos = new Vector2(-1, 1);
                    break;
                case KeyState.downLeft:
                    pos = new Vector2(-1, -1);
                    break;
                case KeyState.up:
                    pos = Vector2.up;
                    break;
                case KeyState.down:
                    pos = Vector2.down;
                    break;
                case KeyState.left:
                    pos = Vector2.left;
                    break;
                case KeyState.right:
                    pos = Vector2.right;
                    break;
                case KeyState.none:
                    pos = Vector2.zero;
                    break;
            }
        }
        KeyState keyState;
        public enum KeyState
        {
            upRight,
            downRight,
            upLeft,
            downLeft,
            up,
            down,
            left,
            right,
            none
        }
#endif
    }

}