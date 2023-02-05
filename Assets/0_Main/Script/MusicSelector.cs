using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{
    public AudioSource TrackAmbiant;
    public AudioSource TrackEnemyAttack;

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            EnemyTrack();
        }
        if (Input.GetKey(KeyCode.P))
        {
            AmbiantTrack();
        }
    }
    private void Start()
    {
        TrackAmbiant.Play();
        TrackAmbiant.mute = false;

        TrackEnemyAttack.Play();
        TrackEnemyAttack.mute = true;
    }

    // When creating new room EnemyAttack is unmute : CreateRoom()?
    public void EnemyTrack()
    {
        TrackAmbiant.mute = true;
        TrackEnemyAttack.mute = false;
    }

    // When door are created Ambiant is unmute: CreateDoor()?
    public void AmbiantTrack()
    {
        TrackEnemyAttack.mute = true;
        TrackAmbiant.mute = false;
    }
}
