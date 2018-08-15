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
    private float animationDuration = 0.2f;

	private void Update() {
        if (Input.GetKeyDown(KeyCode.A))
            OnTheOneButtonClick();

		if (menuAnimating)
        {
            if (areMenuShowing)
            {
                menuAnimationTransition += Time.deltaTime * (1 - animationDuration);
                if (menuAnimationTransition >= 1)
                {
                    menuAnimationTransition = 1;
                    menuAnimating = false;
                }
            }
            else
            {
                menuAnimationTransition -= Time.deltaTime * (1 - animationDuration);
                if (menuAnimationTransition <= 0)
                {
                    menuAnimationTransition = 0;
                    menuAnimating = false;
                }
            }
            colorMenu.anchoredPosition = Vector2.Lerp(new Vector2(0, 500), new Vector2(0, -125), menuAnimationTransition);
            actionMenu.anchoredPosition = Vector2.Lerp(new Vector2(-375, 0), new Vector2(125, 0), menuAnimationTransition);
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
