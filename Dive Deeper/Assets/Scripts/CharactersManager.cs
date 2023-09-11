using System;
using UnityEngine;
using Yarn.Unity;
/*
* Character manager to show characters during dialogue. Add a renderer in another GameObject and move said renderer around to the position you want.
* Add a character object to hold the character sprite and name data.
*/
public class CharactersManager : MonoBehaviour
{
    public static CharactersManager instance;

    [SerializeField] private SpriteRenderer[] positions;
    [SerializeField] private Character[] characters;

    private void Start() {
        if (instance == null) {
            instance = this;
        }

        foreach (SpriteRenderer spriteRenderer in positions) {
            Color color = Color.white;
            color.a = 0;
            spriteRenderer.color = color;
        }
    }
    /*
    * Position is where you want the sprite to show up and the name is what character to show. You assign the name in the character array along with the sprite.
    * Selecting a character will gray out other characters in the scene.
    * Can only highlight one character at a time.
    */
    [YarnCommand("show_character")]
    public void ShowCharacter(int position, string chName) {
        for (int i = 0; i < positions.Length; i++) {
            if (i == position) {
                Character targetCharacter = Array.Find(characters, ch => ch.characterName == chName);

                if (targetCharacter == null) {
                    Debug.LogWarning("Character name: " + chName + " is missing");
                    return;
                }

                positions[i].sprite = targetCharacter.characterSprite;

                Color color = Color.white;
                color.a = 1f;
                positions[i].color = color;
                continue;
            }

            if (positions[i].color.a != 0) {
                Color color = Color.gray;
                positions[i].color = color;
            }
        }
    }
}
