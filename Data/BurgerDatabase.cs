using Hamburguesa_EduardoHidalgo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburguesa_EduardoHidalgo.Data
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
            //Init();
            //int result = conn.Insert(burger);
            //return result;

            if(burger.Id != 0)
            {
                return conn.Update(burger);
            }
            return conn.Insert(burger);
        }
        public List<Burger> GetAllBurgers()
        {
            Init();
            List<Burger> burgers = conn.Table<Burger>().ToList();
            return burgers;
        }

        public Burger getID(int id)
        {
            Init();
            var burger = from b in conn.Table<Burger>()
                         where b.Id == id
                         select b;

            return burger.FirstOrDefault();
        }
        public void updateData(int id, string name, string description, bool haveCheese)
        {
            Init();
            var burger = conn.Table<Burger>().Where(r => r.Id == id).FirstOrDefault();
            if (burger != null)
            {
                burger.Name = name;
                burger.Description = description;
                burger.WithExtraCheese = haveCheese;

                conn.Update(burger);
            }
        }
        public int deleteBurger(Burger burger)
        {
            Init();
            return conn.Delete(burger);
        }
    }
}
