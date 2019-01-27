using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTriggerManager : MonoBehaviour {

    const string k_ControllerTag = "Controller";

    public enum InteractionType {Pet, Slap};
    public InteractionType interaction;

    PlayerGameController m_playerGameController;

    private void OnEnable()
    {
        m_playerGameController = FindObjectOfType<PlayerGameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(k_ControllerTag))
        {
            switch(interaction)
            {
                case InteractionType.Pet:
                    m_playerGameController.HandleGesture(interaction.ToString());
                break;

                case InteractionType.Slap:
                    m_playerGameController.HandleGesture(interaction.ToString());
                break;
            }
        }
    }
}
