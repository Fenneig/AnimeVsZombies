using System;

namespace AVZ.Characters
{
    public class BuffResolver
    {
        private Player _player;

        public BuffResolver(Player player) => _player = player;
        
        public void Resolve(BuffType buffType, int specialAmount = 0)
        {
            switch (buffType)
            {
                case BuffType.CharactersAmount:
                    if (specialAmount > 0)
                        _player.AddCharacters(specialAmount);
                    else 
                        _player.RemoveCharacters(-specialAmount);
                    break;
                case BuffType.Weapon:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(buffType), buffType, null);
            }
        }
    }
}
