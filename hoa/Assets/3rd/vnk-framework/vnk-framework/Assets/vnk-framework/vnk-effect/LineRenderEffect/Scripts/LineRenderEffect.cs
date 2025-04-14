using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    public enum LineRenderEffectColor
    {
        Red,
        Blue,
        White,
        Pink,
        Green
    }
    public class LineRenderEffect : MonoBehaviour
    {
        [SerializeField] private GameObject bg;

        [SerializeField] private LineRenderer maskBeam;
        [SerializeField] private LineRenderer frontBeam;
        [SerializeField] private LineRenderer backBeam;
        [SerializeField] private LineRenderer backBeamSecond;

        [SerializeField] private LineRenderEffectMaterial redRenderEffectMaterial;
        [SerializeField] private LineRenderEffectMaterial blueRenderEffectMaterial;
        [SerializeField] private LineRenderEffectMaterial whiteRenderEffectMaterial;
        [SerializeField] private LineRenderEffectMaterial pinkRenderEffectMaterial;
        [SerializeField] private LineRenderEffectMaterial greenRenderEffectMaterial;

        public void ChangeColor(LineRenderEffectColor lineRenderEffectColor)
        {
            LineRenderEffectMaterial renderEffectMaterial;
            switch (lineRenderEffectColor)
            {
                case LineRenderEffectColor.Red:
                    renderEffectMaterial = redRenderEffectMaterial;
                    break;
                case LineRenderEffectColor.Blue:
                    renderEffectMaterial = blueRenderEffectMaterial;
                    break;
                case LineRenderEffectColor.White:
                    renderEffectMaterial = whiteRenderEffectMaterial;
                    break;
                case LineRenderEffectColor.Pink:
                    renderEffectMaterial = pinkRenderEffectMaterial;
                    break;
                case LineRenderEffectColor.Green:
                    renderEffectMaterial = greenRenderEffectMaterial;
                    break;
                default:
                    renderEffectMaterial = redRenderEffectMaterial;
                    break;
            }
            maskBeam.material = renderEffectMaterial.MaskBeam;
            frontBeam.material = renderEffectMaterial.FrontBeam;
            backBeam.material = renderEffectMaterial.BackBeam;
            backBeamSecond.material = renderEffectMaterial.BackBeamSecond;
        }

        public void Show()
        {
            bg.SetActive(true);
        }
        public void Hide()
        {
            bg.SetActive(false);
        }

        public void SetPosition(int index, Vector3 position)
        {
            maskBeam.SetPosition(index, position);
            frontBeam.SetPosition(index, position);
            backBeam.SetPosition(index, position);
            backBeamSecond.SetPosition(index, position);
        }
        public void SetWidth(float startWidth, float endWidth)
        {
            maskBeam.SetWidth(startWidth, endWidth);
            frontBeam.SetWidth(startWidth, endWidth);
            backBeam.SetWidth(startWidth, endWidth);
            backBeamSecond.SetWidth(startWidth, endWidth);
        }

    }

}