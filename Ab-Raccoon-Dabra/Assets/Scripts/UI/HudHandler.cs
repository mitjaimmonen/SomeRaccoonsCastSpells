using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHandler : MonoBehaviour
{
    public Text timerText;
    public Text waveNumberText;
    public Text scoreText;
    public Text spellnameText;
    public Text scoreBonusText;
    public Text scoreTimerText;
    public Slider spellTimeSlider;
    public Slider healthbarSlider;
    public LevelManager levelBoss;

    private Player player;
    private Weapon_Spell spell;
    private int oldIndex;
    private float oldHealth;
    private Image sliderBackground;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Player>();
        foreach (var img in spellTimeSlider.GetComponentsInChildren<Transform>())
        {
            if (img.gameObject.name == "Background")
                sliderBackground = img.GetComponentInChildren<Image>();
        }
    }
    private void Update()
    {
        if (oldIndex != player.EquippedSpell)
        {
            oldIndex = player.EquippedSpell;
            spell = player.weapons[player.EquippedSpell].GetComponent<Weapon_Spell>();
            spellnameText.text = spell.spellName;
            sliderBackground.sprite = spell.spellIcon;

        }
        if (oldHealth != player.CurrentHealth)
        {
            float healthPercentage = player.CurrentHealth / player.MaxHealth;
            healthbarSlider.value = healthPercentage;
            oldHealth = player.CurrentHealth;
        }

        timerText.text = "Next wave in: " + levelBoss.TimerForDisplay().ToString("f0");
        scoreText.text = "Score: " + levelBoss.ScoreForDisplay().ToString("f0");
        waveNumberText.text = "Wave: " + (levelBoss.WaveNumberForScore() + 1);
        spellTimeSlider.value = player.weapons[player.EquippedSpell].CooldownTime;

        if (levelBoss.scoreManager.GetScoreBonus() > 1)
        {
            if (levelBoss.scoreManager.GetScoreBonus() % 1 == 0)
            {
                scoreTimerText.text = levelBoss.scoreManager.GetScoreTimer().ToString("f0");
                scoreBonusText.text = "x" + levelBoss.scoreManager.GetScoreBonus().ToString("f0");
            }
            else
            {
                scoreTimerText.text = levelBoss.scoreManager.GetScoreTimer().ToString("f0");
                scoreBonusText.text = "x" + levelBoss.scoreManager.GetScoreBonus().ToString("f1");
            }

        }

        else
        {
            scoreTimerText.text = " ";
            scoreBonusText.text = " ";
        }
    }

}
