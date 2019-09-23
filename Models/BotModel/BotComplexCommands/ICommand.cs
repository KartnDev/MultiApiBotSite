using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMySite.Models.BotModel.BotComplexCommands
{
    public interface ICommand
    {
        void Ban(int userID, int chatID, int time=-1, string reason=null);
        void Chance(string message);
        void Roll(int lowerCase=0, int upperCase=100);
        void Time();


    }
}
