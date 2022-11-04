using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Music_SoundEffects
{
    public class SoundEffectPlayer
    {

        public void LoadSongs(ContentManager content)
        {
             overworldMusic = content.Load<Song>("Music/MainThemeOverworld");
             starmanMusic = content.Load<Song>("Music/Starman");
             underworldMusic = content.Load<Song>("Music/Underworld");
        }
        public void Play(ContentManager content)
        {
            MediaPlayer.Play(overworldMusic);
        }
    }
}
