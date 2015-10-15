using UnityEngine;
using System.Collections;

public class fog : MonoBehaviour {

	public Sprite fogSprite;
	public Sprite realSprite;
	private SpriteRenderer spriteRenderer;

	private bool _enableFog = true;

	void Update(){

	}

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		realSprite = spriteRenderer.sprite;
		spriteRenderer.sprite = fogSprite;
        if (this.gameObject.name.Contains("ammo"))
            print(spriteRenderer.sprite.name);
	}
	
	public void enableFog() {
		if (!_enableFog) {
			_enableFog = true;
			spriteRenderer.sprite = fogSprite;
		}
	}
	
	public void diableFog() {
		if (_enableFog) {
			_enableFog = false;
			spriteRenderer.sprite = realSprite;
		}
	}
}
