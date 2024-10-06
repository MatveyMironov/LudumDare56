using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip[] musicClips;
    private int _selectedClipIndex = 0;
    private bool _isPaused = false;

    private void Start()
    {
        PlaySelectedClip();
    }

    private void Update()
    {
        if (!_isPaused && !musicSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    [ContextMenu("Play Next Clip")]
    public void PlayNextClip()
    {
        SelectNextClip();
        PlaySelectedClip();
    }

    [ContextMenu("Play Previous Clip")]
    public void PlayPreviousClip()
    {
        SelectPreviousClip();
        PlaySelectedClip();
    }

    private void SelectNextClip()
    {
        if (_selectedClipIndex + 1 < musicClips.Length)
        {
            _selectedClipIndex++;
        }
        else
        {
            _selectedClipIndex = 0;
        }
    }

    private void SelectPreviousClip()
    {
        if (_selectedClipIndex > 0)
        {
            _selectedClipIndex--;
        }
        else
        {
            _selectedClipIndex = musicClips.Length - 1;
        }
    }

    private void PlaySelectedClip()
    {
        musicSource.clip = musicClips[_selectedClipIndex];
        if (!_isPaused)
        {
            musicSource.Play();
        }
    }

    [ContextMenu("Pause Music")]
    public void PauseMusic()
    {
        if (_isPaused) { return; }

        musicSource.Pause();
        _isPaused = true;
    }

    [ContextMenu("Unpause Music")]
    public void UnPauseMusic()
    {
        if (!_isPaused) { return; }

        musicSource.UnPause();
        musicSource.Play();
        _isPaused = false;
    }
}
