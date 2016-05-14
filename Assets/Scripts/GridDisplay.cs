using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum TOKEN_TYPES
{
    RED,GREEN,YELLOW,BLUE,NONE
}

public class GridDisplay : MonoBehaviour {

	public Token[,] displayTokens;

  static GameObject prefabButtonStat;
  public GameObject prefabButton;
  static RectTransform ParentPanelStat;
  public RectTransform ParentPanel;

	void Start () {
		initialise();
	}

	public void initialise()
	{
    displayTokens = new Token[4, 4];
    prefabButtonStat = prefabButton;
    ParentPanelStat = ParentPanel;

		for (int x = 0; x < 4; x++)
		{
			for(int y = 0; y < 4; y++)
			{
					displayTokens [x, y] = new Token(x, y);
			}
		}
	}

  static TOKEN_TYPES intToType(int x)
	{
    switch (x)
    {
      case 0:
        return TOKEN_TYPES.RED;
      case 1:
        return TOKEN_TYPES.GREEN;
      case 2:
        return TOKEN_TYPES.YELLOW;
      case 3:
        return TOKEN_TYPES.BLUE;
      default:
        return TOKEN_TYPES.NONE;
    }
	}

	public class Token {
    public int buttonNum;
    public bool selected = false;
    ColorBlock selectedColour;
    ColorBlock normalColour;
    public TOKEN_TYPES type;
    public GameObject ButtonGameObject;
    public Button ButtonToken;

    public Token() {

		}

		public Token(int x, int y) {
			this.type = type;
      createToken(x, y);
		}

    void createToken(int x, int y) {
        buttonNum = y;
        this.type = intToType(x);
        ButtonGameObject = (GameObject)Instantiate(prefabButtonStat);
        ButtonGameObject.transform.SetParent(ParentPanelStat, false);
        ButtonGameObject.transform.localScale = new Vector3(1, 1, 1);

        ButtonToken = ButtonGameObject.GetComponent<Button>();
        TOKEN_TYPES tempType = intToType(x);

        ButtonToken.onClick.AddListener(() => ButtonClicked());
        SetColours();
    }

    void ButtonClicked()
    {
        if (selected) {
          ButtonToken.colors = normalColour;
        } else {
          ButtonToken.colors = selectedColour;
        }
        selected = !selected;
    }

    void SetColours()
    {
      normalColour = ButtonToken.colors;
      switch (type)
      {
        case TOKEN_TYPES.RED:
          Debug.Log ("NONE - Button clicked = ");
          selectedColour = ButtonToken.colors;
          selectedColour.highlightedColor = Color.red;
          selectedColour.normalColor = Color.red;
          break;
        case TOKEN_TYPES.GREEN:
          selectedColour = ButtonToken.colors;
          selectedColour.highlightedColor = Color.green;
          selectedColour.normalColor = Color.green;
          break;
        case TOKEN_TYPES.YELLOW:
          selectedColour = ButtonToken.colors;
          selectedColour.highlightedColor = Color.yellow;
          selectedColour.normalColor = Color.yellow;
          break;
        case TOKEN_TYPES.BLUE:
          selectedColour = ButtonToken.colors;
          selectedColour.highlightedColor = Color.blue;
          selectedColour.normalColor = Color.blue;
          break;
        default:
          selectedColour = ButtonToken.colors;
          break;
      }
    }

	};
}
