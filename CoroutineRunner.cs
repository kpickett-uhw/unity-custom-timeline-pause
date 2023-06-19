using UnityEngine;


//References some code from the excellent template: http://bernardopacheco.net/using-an-event-manager-to-decouple-your-game-in-unity
public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner coroutineRunner;

    public static CoroutineRunner instance
    {
        get
        {
            if (!coroutineRunner)
            {
                coroutineRunner = FindObjectOfType(typeof(CoroutineRunner)) as CoroutineRunner;

                if (!coroutineRunner)
                {
                    Debug.LogError("There needs to be one active CoroutineRunner script on a GameObject in your scene.");
                }
                else
                {
                    //  Sets this to not be destroyed when reloading scene
                    DontDestroyOnLoad(coroutineRunner);
                }
            }
            return coroutineRunner;
        }
    }
}
