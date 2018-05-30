using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHandler : MonoBehaviour
{
    public Text timerText;
    public Text spellnameText;
    public Slider spellTimeSlider;
    public LevelManager levelBoss;

    private Player player;
    private Weapon_Spell spell;
    private int oldIndex;
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
        timerText.text = "Next wave in: " + levelBoss.TimerForDisplay().ToString("f0");
        spellTimeSlider.value = player.weapons[player.EquippedSpell].CooldownTime;
    }

}
