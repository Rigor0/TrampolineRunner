using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool tap, swipeLeft, swipeRight;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;


	void Update()
	{
		tap = swipeLeft = swipeRight = false;
		#region Standalone Inputs
		if (Input.GetMouseButtonDown(0))
		{
			tap = true;
			isDraging = true;
			startTouch = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			isDraging = false;
			Reset();
		}
		#endregion

		#region Mobile Input
		if (Input.touches.Length > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				tap = true;
				isDraging = true;
				startTouch = Input.touches[0].position;
			}

			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				isDraging = false;
				Reset();
			}
		}
		#endregion

		swipeDelta = Vector2.zero;
		if (isDraging)
		{
			if (Input.touches.Length < 0)
			{
				swipeDelta = Input.touches[0].position - startTouch;
			}
			else if (Input.GetMouseButton(0))
			{
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		

	}

	private void Reset()
	{
		startTouch = swipeDelta = Vector2.zero;
		isDraging = false;
	}
}
