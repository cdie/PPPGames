using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.Abstractions
{
    public interface IArmor
    {

        int Resistance { get; }
        void TakeDamage(int damage);
    }
}
