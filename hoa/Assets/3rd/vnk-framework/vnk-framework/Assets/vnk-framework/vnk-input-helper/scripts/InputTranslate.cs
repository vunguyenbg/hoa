using Lean.Common;
using Lean.Touch;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class InputTranslate : MonoBehaviour
    {
		public LeanFingerFilter Use = new LeanFingerFilter(true);
	    protected Camera _camera;
		[SerializeField] private float sensitivity = 1.0f;
		[SerializeField] private float damping = -1.0f;
		[SerializeField] [Range(0.0f, 1.0f)] private float inertia;

		[SerializeField]
		protected Vector3 remainingTranslation;

		public Action<Vector3> OnTranslate;

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			Use.UpdateRequiredSelectable(gameObject);
		}
#endif

		protected virtual void Awake()
		{
			_camera = Camera.main;
			Use.UpdateRequiredSelectable(gameObject);
		}

		protected virtual void Update()
		{
			// Store
			var oldPosition = transform.localPosition;

			// Get the fingers we want to use
			var fingers = Use.UpdateAndGetFingers();

			// Calculate the screenDelta value based on these fingers
			var screenDelta = LeanGesture.GetScreenDelta(fingers);

			if (screenDelta != Vector2.zero)
			{
				Translate(screenDelta);
			}

			// Increment
			remainingTranslation += transform.localPosition - oldPosition;

			// Get t value
			var factor = LeanHelper.GetDampenFactor(damping, Time.deltaTime);

			// Dampen remainingDelta
			var newRemainingTranslation = Vector3.Lerp(remainingTranslation, Vector3.zero, factor);

			// Shift this transform by the change in delta
			transform.localPosition = oldPosition + remainingTranslation - newRemainingTranslation;

			if (fingers.Count == 0 && inertia > 0.0f && damping > 0.0f)
			{
				newRemainingTranslation = Vector3.Lerp(newRemainingTranslation, remainingTranslation, inertia);
			}

			// Update remainingDelta with the dampened value
			remainingTranslation = newRemainingTranslation;
		}


		protected virtual void Translate(Vector2 screenDelta)
		{
			// Make sure the camera exists
			var camera = LeanHelper.GetCamera(this._camera, gameObject);

			// Screen position of the transform
			var screenPoint = camera.WorldToScreenPoint(transform.position);

			// Add the deltaPosition
			screenPoint += (Vector3)screenDelta * sensitivity;

			// Convert back to world space

			OnTranslate?.Invoke(camera.ScreenToWorldPoint(screenPoint));

		}
	}

}