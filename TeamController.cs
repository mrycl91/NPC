using UnityEngine;
using UnityEngine.UI;

public class TempController : MonoBehaviour
{
    [SerializeField] Text textTemp;
    [SerializeField] public float temp;
    Slider tempcontrol;

    // Start is called before the first frame update
    void Start()
    {
        tempcontrol = GetComponent <Slider> ();
        tempcontrol.onValueChanged.AddListener (delegate{
            textTemp.text = "Temperature: " + tempcontrol.value;
            temp = tempcontrol.value;
            
        });
    }

    // Update is called once per frame
    
    void Update()
    {

    }
    
    public float reTemp(){
        Debug.Log(temp);
        return temp;
    }

    /*
    void OnDestroy() {
        //tempcontrol.onClick.RemoveAllListeners();
    }
    */
}
