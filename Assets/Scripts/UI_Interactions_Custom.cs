using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class UI_Interactions_Custom : MonoBehaviour
{
    [SerializeField] GameObject canvasParent;
    [SerializeField] float speed = 10f;
    private int count = 0;

    public void Button_Next()
    {
        print("Moving to next canvas...");
        StartCoroutine(MoveObject.use.Translation(canvasParent.transform, Vector3.left * 3, 1f, MoveObject.MoveType.Speed));
    }

    public void Button_Prev()
    {
        print("Moving to previous canvas...");
        StartCoroutine(MoveObject.use.Translation(canvasParent.transform, Vector3.right * 3, 1f, MoveObject.MoveType.Speed));
    }

}