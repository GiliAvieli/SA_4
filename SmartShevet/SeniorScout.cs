using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public class SeniorScout
    {
        private int seniorscoutId;
        private string name;
        private string grade;
        private string role;
        private string email;
        private string phoneNumber;
        private string password;

        public SeniorScout(int id, string name, string grade, string role, string email,
                          string phoneNumber, string password, bool is_new)
        {
            this.seniorscoutId = id;
            this.name = name;
            this.grade = grade;
            this.role = role;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;

            if (is_new)
            {
                this.createSeniorScout();
                Program.SeniorScouts.Add(this);
            }
        }

        public int getId() { return this.seniorscoutId; }
        public string getName() { return this.name; }
        public string getGrade() { return this.grade; }
        public string getRole() { return this.role; }
        public string getEmail() { return this.email; }
        public string getPhoneNumber() { return this.phoneNumber; }
        public string getPassword() { return this.password; }

        public void setName(string name) { this.name = name; }
        public void setGrade(string grade) { this.grade = grade; }
        public void setRole(string role) { this.role = role; }
        public void setEmail(string email) { this.email = email; }
        public void setPhoneNumber(string phoneNumber) { this.phoneNumber = phoneNumber; }
        public void setPassword(string password) { this.password = password; }

        public void createSeniorScout()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_seniorscout_create @seniorscout_id, @name, @grade, @role, @email, @phoneNumber, @password";
            cmd.Parameters.AddWithValue("@seniorscout_id", this.seniorscoutId);
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@grade", this.grade);
            cmd.Parameters.AddWithValue("@role", this.role);
            cmd.Parameters.AddWithValue("@email", this.email);
            cmd.Parameters.AddWithValue("@phoneNumber", this.phoneNumber);
            cmd.Parameters.AddWithValue("@password", this.password);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateSeniorScout()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_seniorscout_update @seniorscout_id, @name, @grade, @role, @email, @phoneNumber, @password";
            cmd.Parameters.AddWithValue("@seniorscout_id", this.seniorscoutId);
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@grade", this.grade);
            cmd.Parameters.AddWithValue("@role", this.role);
            cmd.Parameters.AddWithValue("@email", this.email);
            cmd.Parameters.AddWithValue("@phoneNumber", this.phoneNumber);
            cmd.Parameters.AddWithValue("@password", this.password);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteSeniorScout()
        {
            Program.SeniorScouts.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_seniorscout_delete @seniorscout_id";
            cmd.Parameters.AddWithValue("@seniorscout_id", this.seniorscoutId);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public static void initSeniorScouts()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_seniorscout_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.SeniorScouts = new List<SeniorScout>();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string grade = rdr.GetString(2);
                string role = rdr.GetString(3);
                string email = rdr.GetString(4);
                string phoneNumber = rdr.GetString(5);
                string password = rdr.GetString(6);

                SeniorScout ss = new SeniorScout(id, name, grade, role, email, phoneNumber, password, false);
                Program.SeniorScouts.Add(ss);
            }
        }

        public static SeniorScout seekSeniorScout(int id)
        {
            foreach (SeniorScout ss in Program.SeniorScouts)
            {
                if (ss.getId() == id)
                    return ss;
            }
            return null;
        }

        public static int getNextSeniorScoutId()
        {
            if (Program.SeniorScouts.Count == 0)
                return 1;

            int maxId = 0;
            foreach (SeniorScout ss in Program.SeniorScouts)
            {
                if (ss.getId() > maxId)
                    maxId = ss.getId();
            }
            return maxId + 1;
        }
    }
}
