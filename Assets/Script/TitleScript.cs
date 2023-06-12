using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TitleScript : MonoBehaviour
{
    [SerializeField] Image[] images = new Image[2];
    [SerializeField] Color SelectColor = Color.white;
    [SerializeField] UnityEvent Onstart;
    [SerializeField] UnityEvent Onend;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = Color.white;
        }

        images[0].color = SelectColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        var input = Keyboard.current;
        if (input == null) return;

        var a = input.aKey;
        var d = input.dKey;
        var space = input.spaceKey;

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
        }

        if (space.wasPressedThisFrame)
        {
            switch (index)
            {
                case 0:
                    Debug.Log("start");
                    Onstart.Invoke();
                    break;

                case 1:
                    Debug.Log("end");
                    Onend.Invoke();
                    break;
            }

        }

    }
}
