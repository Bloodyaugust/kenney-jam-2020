using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour {
    private TextMeshProUGUI scoreText;
    private UIController uiController;

    void Awake() {
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        uiController = UIController.Instance;

        uiController.StoreUpdated += OnStoreUpdated;
    }

    void OnStoreUpdated(string storeKey) {
        if (storeKey == "Score") {
            scoreText.text = uiController.Store[storeKey].ToString();
        }
    }
}
