using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Music_SoundEffects
{
    public class MusicPlayer
    {

        public void LoadSongs(ContentManager content)
        {
            Song overworldMusic = content.Load<Song>("Music/MainThemeOverworld");
            Song starmanMusic = content.Load<Song>("Music/Starman");
            Song underworldMusic = content.Load<Song>("Music/Underworld");


        }
        public void Play(ContentManager content)
        {
            
        }
    }
}
