using System.Collections.Generic;
using UnityEngine;

public static class AudioRegistry {
    private static readonly List<string> Sounds = new List<string> {
        "switch2",
        "switch22",
        "switch23",
        "sfx100v2_misc_02", // water refill
        "sfx100v2_misc_27", // hoe
        "sfx100v2_misc_30", // item pickup
        "sfx100v2_misc_32", // inventory open
        "sfx100v2_wood_04", // inventory close
        "sfx100v2_items_01", // buy
        "sfx100v2_items_02", // sell
        "sfx100v2_stones_02", // watering can
    };
    private static readonly Dictionary<string, AudioClip> Clips = new Dictionary<string, AudioClip>();

    public static void Init() {
        foreach(string key in Sounds) {
            AudioClip clip = Resources.Load<AudioClip>("Audio/" + key);
            if(clip == null) {
                Debug.LogError("AudioClip not found: " + key);
            } else {
                Clips[key] = clip;
            }
        }
    }

    public static void Play(string key) {
        GameController.instance.sfxSource.PlayOneShot(Clips[key]);
    }
}
