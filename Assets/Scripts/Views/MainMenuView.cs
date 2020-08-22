using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour {
    new private Animation animation;
    private AnimationState mainMenuAnimation;
    private bool shown;
    private Button playButton;
    private RectTransform view;
    private UIController uiController;

    public void OnItchButtonClicked() {
        Application.OpenURL("https://synsugarstudio.itch.io/");
    }

    public void OnTwitterButtonClicked() {
        Application.OpenURL("https://twitter.com/Bloodyaugust");
    }

    void Awake() {
        animation = GetComponent<Animation>();
        mainMenuAnimation = animation["MainMenuAnimation"];
        playButton = transform.Find("PlayButton").GetComponent<Button>();
        uiController = UIController.Instance;
        view = GetComponent<RectTransform>();

        playButton.onClick.AddListener(OnPlayButtonClicked);
        uiController.StoreUpdated += OnStoreUpdated;
    }

    void Hide() {
        shown = false;

        mainMenuAnimation.time = mainMenuAnimation.length;
        mainMenuAnimation.speed = -1;
        animation.Play();
    }

    void OnPlayButtonClicked() {
        uiController.ResetStore();
        uiController.SetValue("GameState", GameState.Loading);
    }

    void OnStoreUpdated(string storeKey) {
        if (storeKey == "GameState") {
            if (uiController.Store[storeKey] == GameState.Menu && shown == false) {
                Show();
            }

            if (uiController.Store[storeKey] != GameState.Menu && shown == true) {
                Hide();
            }
        }
    }

    void Show() {
        shown = true;

        mainMenuAnimation.time = 0;
        mainMenuAnimation.speed = 1;
        animation.Play();
    }

    void Start() {
        Show();
    }
}
