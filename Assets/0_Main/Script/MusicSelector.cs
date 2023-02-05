using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{
    public AudioSource TrackAmbiant;
    public AudioSource TrackEnemyAttack;

    private void Awake()
    {
        TrackAmbiant.Play();

        TrackEnemyAttack.Play();
        TrackEnemyAttack.mute = true;

    }

    // When creating new room EnemyAttack is unmute
    public void EnemyTrack()
    {
        TrackAmbiant.mute = true;
        TrackEnemyAttack.mute = false;
    }

    // When door are created Ambiant is unmute
    public void AmbiantTrack()
    {
        TrackEnemyAttack.mute = true;
        TrackAmbiant.mute = false;
    }
}
