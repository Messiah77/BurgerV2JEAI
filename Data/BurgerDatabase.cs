using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerV2JEAI.Models;
using SQLite;

namespace BurgerV2JEAI.Data
{
    
    public class BurgerDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public BurgerDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Burger>();
        }

        public int AddNewBurger(Burger burger)
        {
            Init();
            int result = conn.Insert(burger);
            return result;
        }

        public int UpadateBurger(Burger burger)
        {
            Init();
            int result = conn.Update(burger);
            return result;
        }

        public int DeleteBurger(Burger burger)
        {
            Init();
            int result = conn.Delete(burger);
            return result;
        }

        public List<Burger> GetAllBurgers()
        {
            Init();
            List<Burger> burgers = conn.Table<Burger>().ToList();
            return burgers;
        }

        public Burger GetBurger(int id)
        {
            Burger B1 = new Burger();
            Init();
            List<Burger> burgers = conn.Table<Burger>().ToList();
            foreach (Burger B2 in burgers)
            {
                if (B2.ID == id)
                    B1 = B2;
            }
            return B1;
        }
    }
}
