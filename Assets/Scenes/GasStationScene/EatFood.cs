using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EatFood : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        print(gameObject + " collided with " + other.gameObject);

        if (other.tag != "Hand")
        {
            // Check tags and load scene depending on type of food eaten.
            // Done asynchronously so that the player can simply leave the
            // start zone without having to wait for a loading screen.
            // Depending on how we set up difficulty levels, it might be easier
            // to just alter values on the fly
            switch (gameObject.tag)
            {
                case "Easy":
                    StartCoroutine(LoadAsyncScene("Easy"));
                    break;
                case "Medium":
                    StartCoroutine(LoadAsyncScene("Medium"));
                    break;
                case "Hard":
                    StartCoroutine(LoadAsyncScene("Hard"));
                    break;
                default:
                    return;
            }
        }
    }

    IEnumerator LoadAsyncScene(string sceneName)
    {
        print("Loading scene: " + sceneName);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
