using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public class EquipmentIssue
    {
        private int equipmentissueId;
        private DateTime issueDate;
        private DateTime? returnDate;
        private int equipmentId;
        private int issuedToId;
        private int reservationId;
        private string status;
        private string condition;

        public EquipmentIssue(int id, DateTime issueDate, DateTime? returnDate, int equipmentId, int issuedToId,
                             int reservationId, string status, string condition, bool is_new)
        {
            this.equipmentissueId = id;
            this.issueDate = issueDate;
            this.returnDate = returnDate;
            this.equipmentId = equipmentId;
            this.issuedToId = issuedToId;
            this.reservationId = reservationId;
            this.status = status;
            this.condition = condition;

            if (is_new)
            {
                this.createEquipmentIssue();
                Program.EquipmentIssues.Add(this);
            }
        }

        public int getId() { return this.equipmentissueId; }
        public DateTime getIssueDate() { return this.issueDate; }
        public DateTime? getReturnDate() { return this.returnDate; }
        public int getEquipmentId() { return this.equipmentId; }
        public int getIssuedToId() { return this.issuedToId; }
        public int getReservationId() { return this.reservationId; }
        public string getStatus() { return this.status; }
        public string getCondition() { return this.condition; }

        public void setIssueDate(DateTime issueDate) { this.issueDate = issueDate; }
        public void setReturnDate(DateTime? returnDate) { this.returnDate = returnDate; }
        public void setEquipmentId(int equipmentId) { this.equipmentId = equipmentId; }
        public void setIssuedToId(int issuedToId) { this.issuedToId = issuedToId; }
        public void setReservationId(int reservationId) { this.reservationId = reservationId; }
        public void setStatus(string status) { this.status = status; }
        public void setCondition(string condition) { this.condition = condition; }

        public Equipment getEquipment()
        {
            return Equipment.seekEquipment(this.equipmentId);
        }

        public SeniorScout getIssuedTo()
        {
            return SeniorScout.seekSeniorScout(this.issuedToId);
        }

        public EquipmentReservation getReservation()
        {
            return EquipmentReservation.seekEquipmentReservation(this.reservationId);
        }

        public void createEquipmentIssue()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentissue_create @equipmentissue_id, @issueDate, @returnDate, @equipmentId, @issuedToId, @reservationId, @status, @condition";
            cmd.Parameters.AddWithValue("@equipmentissue_id", this.equipmentissueId);
            cmd.Parameters.AddWithValue("@issueDate", this.issueDate);
            cmd.Parameters.AddWithValue("@returnDate", this.returnDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@equipmentId", this.equipmentId);
            cmd.Parameters.AddWithValue("@issuedToId", this.issuedToId);
            cmd.Parameters.AddWithValue("@reservationId", this.reservationId);
            cmd.Parameters.AddWithValue("@status", this.status);
            cmd.Parameters.AddWithValue("@condition", this.condition);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateEquipmentIssue()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentissue_update @equipmentissue_id, @issueDate, @returnDate, @equipmentId, @issuedToId, @reservationId, @status, @condition";
            cmd.Parameters.AddWithValue("@equipmentissue_id", this.equipmentissueId);
            cmd.Parameters.AddWithValue("@issueDate", this.issueDate);
            cmd.Parameters.AddWithValue("@returnDate", this.returnDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@equipmentId", this.equipmentId);
            cmd.Parameters.AddWithValue("@issuedToId", this.issuedToId);
            cmd.Parameters.AddWithValue("@reservationId", this.reservationId);
            cmd.Parameters.AddWithValue("@status", this.status);
            cmd.Parameters.AddWithValue("@condition", this.condition);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteEquipmentIssue()
        {
            Program.EquipmentIssues.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentissue_delete @equipmentissue_id";
            cmd.Parameters.AddWithValue("@equipmentissue_id", this.equipmentissueId);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public static void initEquipmentIssues()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentissue_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.EquipmentIssues = new List<EquipmentIssue>();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                DateTime issueDate = rdr.GetDateTime(1);
                DateTime? returnDate = rdr.IsDBNull(2) ? (DateTime?)null : rdr.GetDateTime(2);
                int equipmentId = rdr.GetInt32(3);
                int issuedToId = rdr.GetInt32(4);
                int reservationId = rdr.GetInt32(5);
                // Guard against SQL NULLs to avoid SqlNullValueException
                string status = rdr.IsDBNull(6) ? string.Empty : rdr.GetString(6);
                string condition = rdr.IsDBNull(7) ? string.Empty : rdr.GetString(7);

                EquipmentIssue ei = new EquipmentIssue(id, issueDate, returnDate, equipmentId, issuedToId, reservationId, status, condition, false);
                Program.EquipmentIssues.Add(ei);
            }
        }

        public static EquipmentIssue seekEquipmentIssue(int id)
        {
            foreach (EquipmentIssue ei in Program.EquipmentIssues)
            {
                if (ei.getId() == id)
                    return ei;
            }
            return null;
        }

        public static int getNextEquipmentIssueId()
        {
            if (Program.EquipmentIssues.Count == 0)
                return 1;

            int maxId = 0;
            foreach (EquipmentIssue ei in Program.EquipmentIssues)
            {
                if (ei.getId() > maxId)
                    maxId = ei.getId();
            }
            return maxId + 1;
        }

        // =====================================================================
        // STATE MACHINE TRANSITIONS
        // =====================================================================

        public void issueEquipment()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentissue_issue @equipmentissue_id";
                cmd.Parameters.AddWithValue("@equipmentissue_id", this.equipmentissueId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "issued";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בהנפקת ציוד: {ex.Message}");
            }
        }

        public void returnEquipment(bool allItemsReturned)
        {
            if (this.status != "issued" && this.status != "not_returned")
                throw new InvalidOperationException("לא ניתן להחזיר ציוד בסטטוס זה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentissue_return @equipmentissue_id, @allReturned";
                cmd.Parameters.AddWithValue("@equipmentissue_id", this.equipmentissueId);
                cmd.Parameters.AddWithValue("@allReturned", allItemsReturned ? 1 : 0);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.returnDate = DateTime.Now;
                this.status = allItemsReturned ? "returned" : "partially_returned";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בקבלת ציוד: {ex.Message}");
            }
        }

        public void reportMissing()
        {
            if (this.status != "issued")
                throw new InvalidOperationException("לא ניתן לדווח על אובדן בסטטוס זה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentissue_report_missing @equipmentissue_id";
                cmd.Parameters.AddWithValue("@equipmentissue_id", this.equipmentissueId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "not_returned";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בדיווח אובדן: {ex.Message}");
            }
        }

        public void finalizeReturn()
        {
            if (this.status != "returned" && this.status != "partially_returned")
                throw new InvalidOperationException("לא ניתן לסיים החזרה בסטטוס זה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentissue_finalize @equipmentissue_id";
                cmd.Parameters.AddWithValue("@equipmentissue_id", this.equipmentissueId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "completed";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בסיום החזרה: {ex.Message}");
            }
        }

        public void itemLocated()
        {
            if (this.status != "not_returned")
                throw new InvalidOperationException("לא ניתן לאשר מציאה בסטטוס זה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentissue_item_found @equipmentissue_id";
                cmd.Parameters.AddWithValue("@equipmentissue_id", this.equipmentissueId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.returnDate = DateTime.Now;
                this.status = "returned";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה במציאת פריט: {ex.Message}");
            }
        }
    }
}
