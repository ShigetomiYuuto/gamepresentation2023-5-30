using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.Windows;

public class TitleScript : MonoBehaviour
{
    [SerializeField] Image[] images = new Image[2];
    [SerializeField] Color SelectColor = Color.white;
    [SerializeField] UnityEvent Onstart;
    [SerializeField] UnityEvent Onend;
    int index = 0;

    public AudioClip _sound1;
    public AudioClip _sound2;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = Color.white;
        }

        images[0].color = SelectColor;

        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        var input = Keyboard.current;
        if (input == null) return;

        var a = input.aKey;
        var d = input.dKey;
        Space();

        if (a.wasPressedThisFrame)
        {
            Debug.Log("a");
            images[index].color = Color.white;
            index--;
            if (index == -1)
            {
                index = 1;
            }

            images[index].color = SelectColor;

            _audioSource.PlayOneShot(_sound1);
        }

        if (d.wasPressedThisFrame)
        {
            Debug.Log("d");
            images[index].color = Color.white;
            index++;
            if (index == images.Length)
            {
                index = 0;
            }

            images[index].color = SelectColor;

            _audioSource.PlayOneShot(_sound1);
        }
    }

    void Space()
    {
        var input = Keyboard.current;
        if (input == null) return;
        var space = input.spaceKey;

        if (space.wasPressedThisFrame)
        {

            switch (index)
            {
                case 0:
                    Debug.Log("start");
                    Onstart.Invoke();
                    AudioSource.PlayClipAtPoint(_sound2, transform.position);
                    break;

                case 1:
                    Debug.Log("end");
                    Onend.Invoke();
                    AudioSource.PlayClipAtPoint(_sound2, transform.position);
                    break;
            }

        }
    }
}