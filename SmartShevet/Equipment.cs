using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public class Equipment
    {
        private int equipmentId;
        private string name;
        private string category;
        private string description;
        private string equipmentType;
        private string containerType;
        private int quantity;
        private int? minimumQuantity;
        private string status;
        private DateTime lastUpdated;
        private string notes;

        public Equipment(int id, string name, string category, string description, string equipmentType,
                        string containerType, int quantity, int? minimumQuantity, string status,
                        DateTime lastUpdated, string notes, bool is_new)
        {
            this.equipmentId = id;
            this.name = name;
            this.category = category;
            this.description = description;
            this.equipmentType = equipmentType;
            this.containerType = containerType;
            this.quantity = quantity;
            this.minimumQuantity = minimumQuantity;
            this.status = status;
            this.lastUpdated = lastUpdated;
            this.notes = notes;

            if (is_new)
            {
                this.createEquipment();
                Program.Equipments.Add(this);
            }
        }

        public int getId() { return this.equipmentId; }
        public string getName() { return this.name; }
        public string getCategory() { return this.category; }
        public string getDescription() { return this.description; }
        public string getEquipmentType() { return this.equipmentType; }
        public string getContainerType() { return this.containerType; }
        public int getQuantity() { return this.quantity; }
        public int? getMinimumQuantity() { return this.minimumQuantity; }
        public string getStatus() { return this.status; }
        public DateTime getLastUpdated() { return this.lastUpdated; }
        public string getNotes() { return this.notes; }

        public void setName(string name) { this.name = name; }
        public void setCategory(string category) { this.category = category; }
        public void setDescription(string description) { this.description = description; }
        public void setEquipmentType(string equipmentType) { this.equipmentType = equipmentType; }
        public void setContainerType(string containerType) { this.containerType = containerType; }
        public void setQuantity(int quantity) { this.quantity = quantity; }
        public void setMinimumQuantity(int? minimumQuantity) { this.minimumQuantity = minimumQuantity; }
        public void setStatus(string status) { this.status = status; }
        public void setLastUpdated(DateTime lastUpdated) { this.lastUpdated = lastUpdated; }
        public void setNotes(string notes) { this.notes = notes; }

        public void createEquipment()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipment_create @equipment_id, @name, @category, @description, @equipmentType, @containerType, @quantity, @minimumQuantity, @status, @lastUpdated, @notes";
            cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@category", this.category);
            cmd.Parameters.AddWithValue("@description", this.description);
            cmd.Parameters.AddWithValue("@equipmentType", this.equipmentType);
            cmd.Parameters.AddWithValue("@containerType", this.containerType);
            cmd.Parameters.AddWithValue("@quantity", this.quantity);
            cmd.Parameters.AddWithValue("@minimumQuantity", this.minimumQuantity ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@status", this.status);
            cmd.Parameters.AddWithValue("@lastUpdated", this.lastUpdated);
            cmd.Parameters.AddWithValue("@notes", this.notes);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateEquipment()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipment_update @equipment_id, @name, @category, @description, @equipmentType, @containerType, @quantity, @minimumQuantity, @status, @lastUpdated, @notes";
            cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@category", this.category);
            cmd.Parameters.AddWithValue("@description", this.description);
            cmd.Parameters.AddWithValue("@equipmentType", this.equipmentType);
            cmd.Parameters.AddWithValue("@containerType", this.containerType);
            cmd.Parameters.AddWithValue("@quantity", this.quantity);
            cmd.Parameters.AddWithValue("@minimumQuantity", this.minimumQuantity ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@status", this.status);
            cmd.Parameters.AddWithValue("@lastUpdated", this.lastUpdated);
            cmd.Parameters.AddWithValue("@notes", this.notes);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteEquipment()
        {
            Program.Equipments.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipment_delete @equipment_id";
            cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public static void initEquipments()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipment_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.Equipments = new List<Equipment>();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string category = rdr.GetString(2);
                string description = rdr.GetString(3);
                string equipmentType = rdr.GetString(4);
                string containerType = rdr.GetString(5);
                int quantity = rdr.GetInt32(6);
                int? minimumQuantity = rdr.IsDBNull(7) ? (int?)null : rdr.GetInt32(7);
                string status = rdr.GetString(8);
                DateTime lastUpdated = rdr.GetDateTime(9);
                string notes = rdr.GetString(10);

                Equipment e = new Equipment(id, name, category, description, equipmentType, containerType,
                                           quantity, minimumQuantity, status, lastUpdated, notes, false);
                Program.Equipments.Add(e);
            }
        }

        public static Equipment seekEquipment(int id)
        {
            foreach (Equipment e in Program.Equipments)
            {
                if (e.getId() == id)
                    return e;
            }
            return null;
        }

        public static int getNextEquipmentId()
        {
            if (Program.Equipments.Count == 0)
                return 1;

            int maxId = 0;
            foreach (Equipment e in Program.Equipments)
            {
                if (e.getId() > maxId)
                    maxId = e.getId();
            }
            return maxId + 1;
        }

        // =====================================================================
        // STATE MACHINE TRANSITIONS
        // =====================================================================

        public void reserveEquipment()
        {
            if (this.status != "available")
                throw new InvalidOperationException("לא ניתן להזמין ציוד שאינו זמין");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_reserve @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "reserved";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בהזמנת ציוד: {ex.Message}");
            }
        }

        public void cancelReservation()
        {
            if (this.status != "reserved")
                throw new InvalidOperationException("לא ניתן לבטל הזמנה של ציוד שאינו בעמדת הזמנה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_cancel_reservation @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "available";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בביטול הזמנה: {ex.Message}");
            }
        }

        public void issueEquipment()
        {
            if (this.status != "reserved")
                throw new InvalidOperationException("לא ניתן להנפיק ציוד שאינו בעמדת הזמנה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_issue @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "borrowed";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בהנפקת ציוד: {ex.Message}");
            }
        }

        public void returnEquipment()
        {
            if (this.status != "borrowed")
                throw new InvalidOperationException("לא ניתן להחזיר ציוד שאינו בשימוש");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_return @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "in_warehouse";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בקבלת ציוד: {ex.Message}");
            }
        }

        public void confirmCondition()
        {
            if (this.status != "in_warehouse")
                throw new InvalidOperationException("לא ניתן לאשר מצב של ציוד שאינו במחסן");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_confirm_condition @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "available";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה באישור מצב: {ex.Message}");
            }
        }

        public void reportDamage()
        {
            if (this.status != "in_warehouse")
                throw new InvalidOperationException("לא ניתן לדווח על נזק של ציוד שאינו במחסן");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_report_damage @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "damaged";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בדיווח נזק: {ex.Message}");
            }
        }

        public void submitForRepair()
        {
            if (this.status != "damaged")
                throw new InvalidOperationException("לא ניתן להגיש לתיקון ציוד שאינו פגום");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_submit_for_repair @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "repair";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בהגשה לתיקון: {ex.Message}");
            }
        }

        public void completionConfirmed()
        {
            if (this.status != "repair")
                throw new InvalidOperationException("לא ניתן לאשר השלמה של ציוד שאינו בתיקון");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_completion_confirmed @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "available";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה באישור השלמה: {ex.Message}");
            }
        }

        public void reportMissing()
        {
            if (this.status != "borrowed")
                throw new InvalidOperationException("לא ניתן לדווח על אובדן ציוד שאינו בשימוש");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_report_missing @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "missing";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בדיווח אובדן: {ex.Message}");
            }
        }

        public void itemFound()
        {
            if (this.status != "missing")
                throw new InvalidOperationException("לא ניתן לאשר מציאה של ציוד שאינו אבוד");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipment_item_found @equipment_id";
                cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.status = "available";
                this.lastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה במציאת פריט: {ex.Message}");
            }
        }
    }
}
