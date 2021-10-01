using AmigaWorld.Entity;
using System.Collections.Generic;
using System.Web.Services;

namespace AmigaWorld.Service
{
    /// <summary>
    /// Summary description for Gamers
    /// </summary>
    [WebService(Namespace = "http://azon.org/services/gamers")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class GamersService : WebService
    {

        [WebMethod]
        public int GetTotalPlayersCount(string region)
        {
            return 100;
        }

        [WebMethod]
        public List<Player> GetPlayers(string region)
        {
            return new List<Player>();
        }

        [WebMethod]
        public void IncreaseLevel(Player player,int levelValue)
        {
            
        }

        private void DoSomething() // Burası ele alınmamalı
        {

        }
    }
}
