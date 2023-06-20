using Diplom1.Components;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom1.Models
{
    public class UserRepository
    {
        public bool AddUser(Person person)
        {
            person.Id = AddUser(Otchestvo: person.Otchestvo, Name: person.Name, Surname: person.Surname, Telephone: person.Telephone);
            return person.Id > 0;
        }

        public int AddUser(string Otchestvo, string Name, string Surname, string Telephone)
        {
            int Id = 0;
            using (MySqlConnection _connection =  ConnectionManager.GetConnection())
            {
                string sql = "Insert into 'employees'('Surname', 'Name', 'Otchestvo', 'Telephone') Values (@Surname,@Name,@Otchestvo,@Telephone)";
                using (MySqlCommand cmd = new MySqlCommand(sql, _connection))
                {
                    cmd.Parameters.Add("Surname", MySqlDbType.String).Value = Surname;
                    cmd.Parameters.Add("Otchestvo", MySqlDbType.String).Value = Otchestvo;
                    cmd.Parameters.Add("Name", MySqlDbType.String).Value = Name;
                    cmd.Parameters.Add("Telephone", MySqlDbType.String).Value = Telephone;
                    _connection.Open();
                    if (cmd.ExecuteNonQuery() >= 0)
                    {
                        sql = "Select last_insert_Id() as Id";
                        cmd.CommandText = sql;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out Id);
                    }
                }
            }

            return Id;
                
        }

        public bool ChangeUser(Person person)
        {
            return ChangeUser(Id: person.Id, Otchestvo: person.Otchestvo, Surname: person.Surname, Name: person.Name, Telephone: person.Telephone);
        }

        public bool ChangeUser(int Id, string Otchestvo, string Name, string Surname, string Telephone)
        {
            bool result = false;
            if (Id > 0)
            {
                
                using (MySqlConnection _connection = ConnectionManager.GetConnection())
                
                {
                    string sql = "Update 'employees' set 'Surname'= @Surname, 'Name' = @Name, 'Otchestvo' = @Otchestvo, 'Telephone' = @Telephone";
                     using (MySqlCommand cmd = new MySqlCommand(sql, _connection))
                    {
                        cmd.Parameters.Add("Surname", MySqlDbType.String).Value = Surname;
                        cmd.Parameters.Add("Otchestvo", MySqlDbType.String).Value = Otchestvo;
                        cmd.Parameters.Add("Name", MySqlDbType.String).Value = Name;
                        cmd.Parameters.Add("Telephone", MySqlDbType.String).Value = Telephone;
                        _connection.Open();
                    }

                }


            }
            return result;
        }

        public bool RemoveUser(Person person)
        {
            return RemoveUser(person.Id);
        }

        public bool RemoveUser(int Id)
        {
            using (MySqlConnection _connection = ConnectionManager.GetConnection())
            {
                string sql = "Delete from 'employees' where 'Id' = @Id";
                using (MySqlCommand cmd = new MySqlCommand(sql, _connection))
                {
                    cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = Id;
                    _connection.Open();
                    return cmd.ExecuteNonQuery() >= 0;
                }
            }
 
        }

        public Person FetchByID(int Id)
        {
            Person person = null;
            using (MySqlConnection objConnect = ConnectionManager.GetConnection())
            {
                string strSQL = "Select p.'Id', p.'Surname', p.'Name', p.'Otchestvo', p.'Telephone'";
                using (MySqlCommand cmd = new MySqlCommand(strSQL, objConnect))
                {
                    objConnect.Open();
                    int id = 0;
                    string Surname = null, Name = null, Otchestvo = null, Telephone = null;
                    cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = Id;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Id = dr.GetInt32("Id");
                            Surname = dr.GetString("Surname").ToString();
                            Name = dr.GetString("Name").ToString();
                            Otchestvo = dr.GetString("Otchestvo").ToString();
                            Telephone = dr.GetString("Telephone").ToString();
                        }
                    }
                }
            }
            return person;
        }

        public IList<Person> List(string sortOrder, System.Web.Helpers.SortDirection sortDir, int page, int pagesize, out int count)
        {
            List<Person> persons = new List<Person>();
            using (MySqlConnection objConnect = ConnectionManager.GetConnection())
            {
                string sort = "Order by";
                if (sortOrder != null && sortOrder != String.Empty)
                {
                    sort += "`" + sortOrder + "`";
                    if (sortDir == System.Web.Helpers.SortDirection.Descending) sort += " DESC";
                    sort += ",";
                }
                sort += "`Id`";
                string limit = "";
                if (pagesize > 0)
                {
                    int start = (page - 1) * pagesize;
                    limit = string.Concat(" LIMIT ", start.ToString(), ", ", pagesize.ToString());
                }
                string strSQL = "SELECT SQL_CALC_FOUND_ROWS p.'Id', p.'Surname', p.'Name', p.'Otchestvo', p.'Telephone'" + sort + limit;
                using (MySqlCommand cmd = new MySqlCommand(strSQL, objConnect))
                {
                    objConnect.Open();
                    cmd.Parameters.Add("page", MySqlDbType.Int32).Value = page;
                    cmd.Parameters.Add("pagesize", MySqlDbType.Int32).Value = pagesize;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        { 
                            persons.Add(new Person(
                                Id: dr.GetInt32("Id"),
                                Surname: dr.GetString("Surname"),
                                Name: dr.GetString("Name"),
                                Otchestvo: dr.GetString("Otchestvo"),
                                Telephone: dr.GetString("Telephone")));
                        }
                    }
                }
                using (MySqlCommand cmdrows = new MySqlCommand("SELECT FOUND_ROWS()", objConnect))
                {
                    int.TryParse(cmdrows.ExecuteScalar().ToString(), out count);
                }
            }
            return persons;
        }
    }
}