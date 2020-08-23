using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {
    Menu,
    Loading,
    Playing,
    Over
}

public class UIController : Singleton<UIController> {
	protected UIController () {}

    public event Action<string> StoreUpdated;

    public Dictionary<string, dynamic> Store;

	static public T RegisterComponent<T> () where T: Component {
		return Instance.GetOrAddComponent<T>();
	}

    public void ResetStore() {
        Store = new Dictionary<string, dynamic>() {
            {"GameState", GameState.Menu},
            {"Score", 0}
        };

        UpdateValue("GameState");
        UpdateValue("Score");
    }

    public void SetValue(string key, dynamic value) {
        Store[key] = value;

        StoreUpdated?.Invoke(key);
    }

    public void UpdateValue(string key) {
        StoreUpdated?.Invoke(key);
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
        ResetStore();
    }
}
