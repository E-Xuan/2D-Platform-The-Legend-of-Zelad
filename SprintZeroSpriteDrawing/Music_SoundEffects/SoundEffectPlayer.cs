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

        public event EventHandler<EventArgs> PlaySoundEffect;

        protected virtual void OnSoundEffectPlayed(EventArgs sound)
        {
            PlaySoundEffect?.Invoke(this, sound);
        }

        public void LoadSongs(ContentManager content)
        {
             
        }
        public void Play(ContentManager content)
        {
           
        }
    }
}
