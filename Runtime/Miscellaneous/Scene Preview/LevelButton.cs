using skv_toolkit;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    
    public string sceneName;
    private Image _previewImage;

    public TextMeshProUGUI buttonText;
    public Button levelButton;

    [SerializeField] private Sprite _previewSprite;
    
    void Awake()
    {
        _previewImage = GameObject.FindGameObjectWithTag("PreviewImage").GetComponent<Image>();
        
        _previewSprite = Resources.Load<Sprite>("LevelPreviews/" + sceneName + "_Preview");

        levelButton.onClick.AddListener(LoadScene);
        buttonText.text = sceneName;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetSprite();
    }

    public void OnSelect(BaseEventData eventData)
    {
        SetSprite();
    }

    void SetSprite()
    {
        if (_previewSprite != null && _previewImage != null)
        {
            _previewImage.sprite = _previewSprite;
        }
    }

    void LoadScene()
    {
        SceneLoader.LoadScene(sceneName);
        // or add a different way to load
    }
}