using ConsoleApp1.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.FACADE
{
    internal class FKITAP
    {
        public static int insert(EKITAP kitap)
        {
            SqlCommand cmd = null;
            //string insertquery = "INSERT INTO KITAP (kitapAdi, sayfaSayisi, yazarID) VALUES ('";
            //insertquery += kitap.kitapAdi + "'," + kitap.sayfaSayisi + ",";
            //insertquery += kitap.yazarID+")";
            CONNECTDB.connect();
            cmd = new SqlCommand("insertBook", CONNECTDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("kitapAdi", kitap.kitapAdi);
            cmd.Parameters.AddWithValue("sayfaSayisi", kitap.sayfaSayisi);
            cmd.Parameters.AddWithValue("yazarID", kitap.yazarID);
            int sonuc = cmd.ExecuteNonQuery();
            return sonuc;
        }
        public static int update(EKITAP kitap)
        {
            CONNECTDB.connect();
            SqlCommand cmd = new SqlCommand("UpdateBook", CONNECTDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("kitapAdi", kitap.kitapAdi);
            cmd.Parameters.AddWithValue("sayfaSayisi", kitap.sayfaSayisi);
            cmd.Parameters.AddWithValue("yazarID", kitap.yazarID);
            cmd.Parameters.AddWithValue("kitapID", kitap.ID);
            int sonuc = cmd.ExecuteNonQuery();
            return sonuc;
        }
        public static int delete(int id)
        {
            SqlCommand cmd = null;
            //string insertquery = "INSERT INTO KITAP (kitapAdi, sayfaSayisi, yazarID) VALUES ('";
            //insertquery += kitap.kitapAdi + "'," + kitap.sayfaSayisi + ",";
            //insertquery += kitap.yazarID+")";
            CONNECTDB.connect();
            cmd = new SqlCommand("deletebyID", CONNECTDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID", id);
            int sonuc = cmd.ExecuteNonQuery();
            return sonuc;
        }

        public static EKITAP selectbyID(int id)
        {
             
            //string str = "Select * from Kitap where kitapID="+id;
            CONNECTDB.connect();
            SqlCommand cmd = new SqlCommand("listByID", CONNECTDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID", id);
            SqlDataReader dreader = cmd.ExecuteReader();
            EKITAP kitap;
            if (dreader.HasRows)
            {
                kitap = new EKITAP();
                while (dreader.Read())
                {
                    kitap.ID = (int)dreader.GetValue(0);
                    kitap.kitapAdi = dreader.GetValue(1).ToString();
                    kitap.sayfaSayisi = (int)dreader.GetValue(2);
                    kitap.yazarID = (int)dreader.GetValue(3);
                    if(dreader.GetDateTime(4)!=null)
                        kitap.eklenmeTarihi = dreader.GetDateTime(4);

                }
                dreader.Close();
                return kitap; 
            }
            CONNECTDB.disconnect();
            return null;
        }

        public static List<EKITAPYAZAR> selectAll()
        {
            List<EKITAPYAZAR> liste=null;
            if(CONNECTDB.con.State!=ConnectionState.Open)
                CONNECTDB.con.Open();
            SqlCommand cmd = new SqlCommand("SPRapor", CONNECTDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dreader = cmd.ExecuteReader();
            EKITAPYAZAR kitap = null;
            liste = new List<EKITAPYAZAR>();
            while (dreader.Read())
            {    
                kitap = new EKITAPYAZAR();
                kitap.ID = (int) dreader.GetValue(0);
                kitap.kitapAdi = dreader.GetValue(1).ToString();
                kitap.sayfaSayisi = (int)dreader.GetValue(2);
                kitap.eklenmeTarihi = dreader.GetDateTime(3);
                kitap.yazarID = (int)dreader.GetValue(4);
                kitap.yazarAdi = dreader.GetValue(5).ToString();
                kitap.yazarSoyadi = dreader.GetValue(6).ToString(); 
                liste.Add(kitap);
            }
            dreader.Close();
            CONNECTDB.con.Close();
            return liste;
        }
    }
}
