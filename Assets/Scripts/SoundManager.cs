using UnityEditor.Timeline.Actions;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource audioSourceObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySound(AudioClip audioClip, Transform transform, float volume)
    {
        //spawn gameObject
        AudioSource audioSource = Instantiate(audioSourceObject, transform.position, Quaternion.identity);
        //assing the AudioClip
        audioSource.clip = audioClip;
        //assign volume
        audioSource.volume = 1f;
        //play sound
        audioSource.Play();
        //get length od source clip
        float clipLenght = audioSource.clip.length;
        //destroy object after clip end
        Destroy(audioSource.gameObject, clipLenght);
    }


}
