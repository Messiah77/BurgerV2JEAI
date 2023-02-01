using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerV2JEAI.Models;
using SQLite;

namespace BurgerV2JEAI.Data
{
    
    public class JEAIBurgerDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public JEAIBurgerDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<JEAIBurger>();
        }

       
        public int AddNewBurger(JEAIBurger burger)
        {
            Init();
            int result = conn.Insert(burger);
            return result;
        }

        public int UpadateBurger(JEAIBurger burger)
        {
            Init();
            int result = conn.Update(burger);
            return result;
        }

        public int DeleteBurger(JEAIBurger burger)
        {
            Init();
            int result = conn.Delete(burger);
            return result;
        }

        public List<JEAIBurger> GetAllBurgers()
        {
            Init();
            List<JEAIBurger> burgers = conn.Table<JEAIBurger>().ToList();
            return burgers;
        }

        public JEAIBurger GetBurger(int id)
        {
            JEAIBurger B1 = new JEAIBurger();
            Init();
            List<JEAIBurger> burgers = conn.Table<JEAIBurger>().ToList();
            foreach (JEAIBurger B2 in burgers)
            {
                if (B2.ID == id)
                    B1 = B2;
            }
            return B1;
        }
    }
}
