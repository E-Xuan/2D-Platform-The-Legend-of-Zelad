using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace SprintZeroSpriteDrawing.Music_SoundEffects
{
    public class MusicPlayer
    {
        Song overworldMusic;
        Song starmanMusic;
        Song underworldMusic;
        private static MusicPlayer _musicPlayer;

        public static MusicPlayer GetMusicPlayer()
        {
            if (_musicPlayer == null)
            {
                _musicPlayer = new MusicPlayer();
            }
            return _musicPlayer;
        }

        public void LoadSongs(ContentManager content)
        {
            overworldMusic = content.Load<Song>("Music/MainThemeOverworld");
            starmanMusic = content.Load<Song>("Music/Starman");
            underworldMusic = content.Load<Song>("Music/Underworld");
        }
        public void PlaySong()
        {
            MediaPlayer.IsMuted = false;
            MediaPlayer.Play(overworldMusic); 
        }
        public void Mute(int mute)
        {
            MediaPlayer.IsMuted = !MediaPlayer.IsMuted;
            
            if(SoundEffect.MasterVolume == 0.0f)
            {
                SoundEffect.MasterVolume = 1.0f;
            }
            else
            {
                SoundEffect.MasterVolume = 0.0f;
            }
        }

       
    }
}
