
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class debugText : MonoBehaviour {
  private Text text;
	public string displayText = "someText";


  void Awake() {
    text = GetComponent<Text>();
  }

  void Update() {
    
    
  }
	public void setText(){
		text.text = displayText;
	}
}
