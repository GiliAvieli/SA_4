using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public class WarehouseStaffMember : SeniorScout
    {
        public WarehouseStaffMember(int id, string name, string grade, string role, string email,
                                   string phoneNumber, string password, bool is_new)
            : base(id, name, grade, role, email, phoneNumber, password, false)
        {
            if (is_new)
            {
                this.createWarehouseStaffMember();
                Program.WarehouseStaffMembers.Add(this);
            }
        }

        public void createWarehouseStaffMember()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_warehousestaffmember_create @warehousestaffmember_id";
            cmd.Parameters.AddWithValue("@warehousestaffmember_id", this.getId());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateWarehouseStaffMember()
        {
            this.updateSeniorScout();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_warehousestaffmember_update @warehousestaffmember_id";
            cmd.Parameters.AddWithValue("@warehousestaffmember_id", this.getId());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteWarehouseStaffMember()
        {
            Program.WarehouseStaffMembers.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_warehousestaffmember_delete @warehousestaffmember_id";
            cmd.Parameters.AddWithValue("@warehousestaffmember_id", this.getId());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
            this.deleteSeniorScout();
        }

        public static void initWarehouseStaffMembers()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_warehousestaffmember_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.WarehouseStaffMembers = new List<WarehouseStaffMember>();

            while (rdr.Read())
            {
                int warehouseStaffMemberId = rdr.GetInt32(0);
                SeniorScout parent = SeniorScout.seekSeniorScout(warehouseStaffMemberId);

                if (parent != null)
                {
                    WarehouseStaffMember wsm = new WarehouseStaffMember(
                        parent.getId(),
                        parent.getName(),
                        parent.getGrade(),
                        parent.getRole(),
                        parent.getEmail(),
                        parent.getPhoneNumber(),
                        parent.getPassword(),
                        false);
                    Program.WarehouseStaffMembers.Add(wsm);
                }
            }
        }

        public static WarehouseStaffMember seekWarehouseStaffMember(int id)
        {
            foreach (WarehouseStaffMember wsm in Program.WarehouseStaffMembers)
            {
                if (wsm.getId() == id)
                    return wsm;
            }
            return null;
        }
    }
}
