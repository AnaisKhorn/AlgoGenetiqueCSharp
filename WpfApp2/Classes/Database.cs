using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Classes
{
        public class Database
        {
            private static Database instance = null;
            private static SQLiteConnection connection = null;

            private Database()
            {
                if (connection == null)
                {
                    connection = new SQLiteConnection("db");

                    if (connection.GetTableInfo("Ville").Count == 0)
                    {
                        connection.CreateTable<Ville>();
                    }

                }

                instance = this;

            }

            public static Database GetDatabase()
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }


            public void saveVille(Ville v)
            {
                connection.Insert(v);
            }

            public List<Ville> getVille()
            {
                return connection.Table<Ville>().ToList<Ville>();
            }

            public ObservableCollection<Ville> GetVilles()
            {
                return new ObservableCollection<Ville>(connection.Table<Ville>().ToList());
            }

            public void DeleteVille(Ville v)
            {
                connection.Delete<Ville>(v.Nom);
            }

            public void DeleteAllVille()
            {
                connection.DeleteAll<Ville>();
            }

            public void KillConnection()
            {
                connection.Close();
                instance = null;
            }


        }
    }
