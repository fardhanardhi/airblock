using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public RectTransform colorMenu;
    public RectTransform actionMenu;

    private bool menuAnimating;
    private bool areMenuShowing;
    private float menuAnimationTransition;

	private void Update() {
        if (Input.GetKeyDown(KeyCode.A))
            OnTheOneButtonClick();

		if (menuAnimating)
        {
            if (areMenuShowing)
            {
                menuAnimationTransition += Time.deltaTime;
                if (menuAnimationTransition >= 1)
                {
                    menuAnimationTransition = 1;
                    menuAnimating = false;
                }
            }
            else
            {
                menuAnimationTransition -= Time.deltaTime;
                if (menuAnimationTransition <= 0)
                {
                    menuAnimationTransition = 0;
                    menuAnimating = false;
                }
            }
            colorMenu.anchoredPosition = Vector2.Lerp(new Vector2(0, 375), new Vector2(0, -125), menuAnimationTransition);
        }
	}

    public void OnTheOneButtonClick()
    {
        areMenuShowing = !areMenuShowing;
        PlayMenuAnimation();
    }

    private void PlayMenuAnimation()
    {
        menuAnimating = true;
    }
    
	void Start () {
		
	}
	
}
