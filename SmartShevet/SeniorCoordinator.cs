using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public class SeniorCoordinator : SeniorScout
    {
        public SeniorCoordinator(int id, string name, string grade, string role, string email,
                               string phoneNumber, string password, bool is_new)
            : base(id, name, grade, role, email, phoneNumber, password, false)
        {
            if (is_new)
            {
                this.createSeniorCoordinator();
                Program.SeniorCoordinators.Add(this);
            }
        }

        public void createSeniorCoordinator()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_seniorcoordinator_create @seniorcoordinator_id";
            cmd.Parameters.AddWithValue("@seniorcoordinator_id", this.getId());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateSeniorCoordinator()
        {
            this.updateSeniorScout();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_seniorcoordinator_update @seniorcoordinator_id";
            cmd.Parameters.AddWithValue("@seniorcoordinator_id", this.getId());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteSeniorCoordinator()
        {
            Program.SeniorCoordinators.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_seniorcoordinator_delete @seniorcoordinator_id";
            cmd.Parameters.AddWithValue("@seniorcoordinator_id", this.getId());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
            this.deleteSeniorScout();
        }

        public static void initSeniorCoordinators()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_seniorcoordinator_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.SeniorCoordinators = new List<SeniorCoordinator>();

            while (rdr.Read())
            {
                int seniorCoordinatorId = rdr.GetInt32(0);
                SeniorScout parent = SeniorScout.seekSeniorScout(seniorCoordinatorId);

                if (parent != null)
                {
                    SeniorCoordinator sc = new SeniorCoordinator(
                        parent.getId(),
                        parent.getName(),
                        parent.getGrade(),
                        parent.getRole(),
                        parent.getEmail(),
                        parent.getPhoneNumber(),
                        parent.getPassword(),
                        false);
                    Program.SeniorCoordinators.Add(sc);
                }
            }
        }

        public static SeniorCoordinator seekSeniorCoordinator(int id)
        {
            foreach (SeniorCoordinator sc in Program.SeniorCoordinators)
            {
                if (sc.getId() == id)
                    return sc;
            }
            return null;
        }
    }
}
