using ConsoleApp1.ENTITY;
using ConsoleApp1.FACADE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BLL
{
    internal class BLLKITAP
    {
        public static int insert(EKITAP kitap)
        {
            if(kitap.kitapAdi.Length>0 && kitap.kitapAdi.Trim().Length>0 && kitap.sayfaSayisi>0)
                return FKITAP.insert(kitap);
            return 0;
        }
        public static int update(EKITAP kitap)
        {
            if (kitap.kitapAdi.Length > 0 && kitap.kitapAdi.Trim().Length > 0 && kitap.sayfaSayisi > 0)
                return FKITAP.update(kitap);
            return 0;
        }
        public static int delete(int id)
        {
            if (id <= 0)
                return 0;
            else
                return FKITAP.delete(id);
        }

        public static EKITAP selectbyID(int id)
        {
            if (id <= 0) 
                return null;
            else 
                return FKITAP.selectbyID(id);
        }

        public static List<EKITAPYAZAR> selectAll()
        {
            return FKITAP.selectAll();
        }
    }
}
