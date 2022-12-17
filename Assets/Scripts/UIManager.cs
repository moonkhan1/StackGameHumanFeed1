using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Settings Panel")]
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject SettingsUIPanel;
    [SerializeField] GameObject TapToPlay;
    [SerializeField] Image _settingButton;
    [SerializeField] Image _pauseButton;
    [SerializeField] Image _exitPauseButton;
    private PlayerController _player;

    [Header("Settings Panel")]
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject WinUIPanel;
    [SerializeField] TMP_Text _feedByMoney;
    [SerializeField] TMP_Text _getMoney;
    [SerializeField] TMP_Text _money;

    [Header("Final Cofigurations")]
    private FinalRoadPancakes _finalRoad;
    [SerializeField] MoneySO _data;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        _finalRoad = FindObjectOfType<FinalRoadPancakes>();

    }
    private void Update() {
        _money.text = _data.Money.ToString();
    }

    private void Start() {
        _pauseButton.enabled = false;
        _exitPauseButton.enabled = false;
        _player = FindObjectOfType<PlayerController>();
        TapToPlay.transform.DOScale(new Vector3(6,2f,2f), 1f).SetLoops(-1, LoopType.Yoyo);
        _finalRoad.GetComponent<FinalRoadPancakes>().OnFinish += OpenWinPanel;
    }
    private void OnEnable()
    {
        _finalRoad.GetComponent<FinalRoadPancakes>().OnFinish += OpenWinPanel;
    }
    private void OnDisable()
    {
        if(_finalRoad !=null)
        _finalRoad.GetComponent<FinalRoadPancakes>().OnFinish -= OpenWinPanel;
    }

    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
        SettingsUIPanel.SetActive(true);
        SettingsUIPanel.transform.localScale = Vector3.zero;
        Image panelImg = SettingsPanel.GetComponent<Image>();
        panelImg.color = new Color(0, 0, 0, 0);
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
        SettingsUIPanel.transform.DOScale(new Vector3(0.35f, 0.27f, 0.3f), 0.2f);
        _settingButton.enabled = false;
    }
    public void CloseSettingsPanel()
    {

        // 
        Image panelImg = SettingsPanel.GetComponent<Image>();
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
        SettingsUIPanel.transform.DOScale(0f, 0.2f).OnComplete(() =>
        {
            SettingsPanel.SetActive(false);
            SettingsUIPanel.SetActive(false);
        });
        _settingButton.enabled = true;
        
    }

    public void TapToPlayButton()
    {

        // Time.timeScale = 1f;
        _player._speed = 10f;
        _settingButton.enabled = false;
        _pauseButton.enabled = true;
        GameObject go = TapToPlay.gameObject;
        Destroy(go);
        
    }

    public void PauseButton()
    {

        // Time.timeScale = 1f;
        _player._speed = 0f;
        _pauseButton.enabled = false;
        _exitPauseButton.enabled = true;
        SettingsPanel.SetActive(true);
        SettingsUIPanel.SetActive(true);
        SettingsUIPanel.transform.localScale = Vector3.zero;
        Image panelImg = SettingsPanel.GetComponent<Image>();
        panelImg.color = new Color(0, 0, 0, 0);
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
        SettingsUIPanel.transform.DOScale(new Vector3(0.35f, 0.27f, 0.3f), 0.2f);
        
    }

    public void ExitPauseButton()
    {

        // Time.timeScale = 1f;
        _player._speed = 10f;
        _pauseButton.enabled = true;
        _exitPauseButton.enabled = false;
        Image panelImg = SettingsPanel.GetComponent<Image>();
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
        SettingsUIPanel.transform.DOScale(0f, 0.2f).OnComplete(() =>
        {
            SettingsPanel.SetActive(false);
            SettingsUIPanel.SetActive(false);
        });
        
    }

    public void OpenWinPanel()
    {
        WinPanel.SetActive(true);
        WinUIPanel.SetActive(true);
        WinUIPanel.transform.localScale = Vector3.zero;
        Image panelImg = WinPanel.GetComponent<Image>();
        panelImg.color = new Color(0, 0, 0, 0);
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
        WinUIPanel.transform.DOScale(new Vector3(1.123f, 1.123f, 1.123f), 0.2f);
        _feedByMoney.text = $"{_data.Money.ToString()} $";
        // _getMoney.text = (System.Convert.ToInt32(DamageNum.Instance.TotalMoney * 0.25f)).ToString();

        // DOTween.To(() => int.Parse(_feedByMoney.text), (x) => _feedByMoney.text = x.ToString(),System.Convert.ToInt32(_data.Money * 1f) + 0, 2f);
        DOTween.To(() => int.Parse(_getMoney.text), (x) => _getMoney.text = x.ToString(), System.Convert.ToInt32(_data.Money* 0.2f) + 0, 2f);


    }

    public void CloseWinPanel()
    {

        // 
        Image panelImg = WinPanel.GetComponent<Image>();
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
        WinUIPanel.transform.DOScale(0f, 0.2f).OnComplete(() =>
        {
            WinPanel.SetActive(false);
            WinUIPanel.SetActive(false);
        });

        // DOTween.To(() => int.Parse(_getMoney.text), (x) => _getMoney.text = x.ToString(), 0, 2f);
        DOTween.To(() => (_data.Money), (x) => _data.Money = x, _data.Money + System.Convert.ToInt32(_getMoney.text), 2f);
        
    }

}
