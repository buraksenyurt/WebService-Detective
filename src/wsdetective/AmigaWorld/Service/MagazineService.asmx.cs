using AmigaWorld.Entity;
using System;
using System.Web.Services;

namespace AmigaWorld.Service
{
    /// <summary>
    /// Summary description for MagazineService
    /// </summary>
    [WebService(Namespace = "http://azon.org/services/magazine/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MagazineService
        : WebService
    {

        [WebMethod]
        public void SaveDocument(byte[] document)
        {
        }

        [WebMethod]
        public Magazine GetDocument(int id, DateTime time)
        {
            return null;
        }
    }
}
