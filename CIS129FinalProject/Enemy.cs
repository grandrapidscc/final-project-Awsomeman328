using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class Enemy : GameUnit
    {
        protected bool _hasMet;
        
        public Enemy()
        {
            _hasMet = false;
        }

        public bool GetHasMet() { return _hasMet; }
        public void SetHasMet(bool hasMet) { _hasMet = hasMet; }
        public string GetAOrAn() 
        {
            if (_unitName.StartsWith("A") || _unitName.StartsWith("E") || _unitName.StartsWith("I") || _unitName.StartsWith("O") || _unitName.StartsWith("U") ||
                _unitName.StartsWith("a") || _unitName.StartsWith("e") || _unitName.StartsWith("i") || _unitName.StartsWith("o") || _unitName.StartsWith("o"))
            {
                return "an";
            }
            else return "a"; 
        }
    }
}
