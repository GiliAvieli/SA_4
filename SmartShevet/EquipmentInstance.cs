using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public class EquipmentInstance
    {
        private int equipmentInstanceId;
        private int equipmentId;
        private string serialNumber;
        private string status;
        private DateTime dateAdded;
        private DateTime lastUpdated;
        private int? reservationDetailId;

        public EquipmentInstance(int id, int equipmentId, string serialNumber, string status,
                               DateTime dateAdded, DateTime lastUpdated, int? reservationDetailId, bool is_new)
        {
            this.equipmentInstanceId = id;
            this.equipmentId = equipmentId;
            this.serialNumber = serialNumber;
            this.status = status;
            this.dateAdded = dateAdded;
            this.lastUpdated = lastUpdated;
            this.reservationDetailId = reservationDetailId;

            if (is_new)
            {
                this.createEquipmentInstance();
                Program.EquipmentInstances.Add(this);
            }
        }

        // =====================================================================
        // GETTERS
        // =====================================================================
        public int getId() { return this.equipmentInstanceId; }
        public int getEquipmentId() { return this.equipmentId; }
        public string getSerialNumber() { return this.serialNumber; }
        public string getStatus() { return this.status; }
        public DateTime getDateAdded() { return this.dateAdded; }
        public DateTime getLastUpdated() { return this.lastUpdated; }
        public int? getReservationDetailId() { return this.reservationDetailId; }

        public Equipment getEquipment()
        {
            return Equipment.seekEquipment(this.equipmentId);
        }

        // =====================================================================
        // SETTERS
        // =====================================================================
        public void setStatus(string status)
        {
            this.status = status;
            this.lastUpdated = DateTime.Now;
        }

        public void setSerialNumber(string serialNumber)
        {
            this.serialNumber = serialNumber;
            this.lastUpdated = DateTime.Now;
        }

        public void setReservationDetailId(int? reservationDetailId)
        {
            this.reservationDetailId = reservationDetailId;
            this.lastUpdated = DateTime.Now;
        }

        // =====================================================================
        // DATABASE CRUD OPERATIONS
        // =====================================================================
        public void createEquipmentInstance()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentinstance_create @equipment_instance_id, @equipment_id, @serial_number, @status";
            cmd.Parameters.AddWithValue("@equipment_instance_id", this.equipmentInstanceId);
            cmd.Parameters.AddWithValue("@equipment_id", this.equipmentId);
            cmd.Parameters.AddWithValue("@serial_number", this.serialNumber);
            cmd.Parameters.AddWithValue("@status", this.status);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateEquipmentInstance()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentinstance_update_reservation @equipment_instance_id, @status, @reservation_detail_id";
            cmd.Parameters.AddWithValue("@equipment_instance_id", this.equipmentInstanceId);
            cmd.Parameters.AddWithValue("@status", this.status);
            cmd.Parameters.AddWithValue("@reservation_detail_id", this.reservationDetailId ?? (object)DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteEquipmentInstance()
        {
            Program.EquipmentInstances.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentinstance_delete @equipment_instance_id";
            cmd.Parameters.AddWithValue("@equipment_instance_id", this.equipmentInstanceId);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // STATIC INITIALIZATION & SEARCH
        // =====================================================================
        public static void initEquipmentInstances()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT equipment_instance_id, equipment_id, serial_number, status, date_added, last_updated, reservation_detail_id FROM EquipmentInstance ORDER BY equipment_id, serial_number";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.EquipmentInstances = new List<EquipmentInstance>();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                int equipmentId = rdr.GetInt32(1);
                string serialNumber = rdr.GetString(2);
                string status = rdr.GetString(3);
                DateTime dateAdded = rdr.GetDateTime(4);
                DateTime lastUpdated = rdr.GetDateTime(5);
                int? reservationDetailId = rdr.IsDBNull(6) ? (int?)null : rdr.GetInt32(6);

                EquipmentInstance ei = new EquipmentInstance(id, equipmentId, serialNumber, status, dateAdded, lastUpdated, reservationDetailId, false);
                Program.EquipmentInstances.Add(ei);
            }
        }

        public static EquipmentInstance seekEquipmentInstance(int id)
        {
            foreach (EquipmentInstance ei in Program.EquipmentInstances)
            {
                if (ei.getId() == id)
                    return ei;
            }
            return null;
        }

        public static int getNextEquipmentInstanceId()
        {
            if (Program.EquipmentInstances.Count == 0)
                return 1;

            int maxId = 0;
            foreach (EquipmentInstance ei in Program.EquipmentInstances)
            {
                if (ei.getId() > maxId)
                    maxId = ei.getId();
            }
            return maxId + 1;
        }

        public static List<EquipmentInstance> getInstancesByEquipmentId(int equipmentId)
        {
            List<EquipmentInstance> result = new List<EquipmentInstance>();
            foreach (EquipmentInstance ei in Program.EquipmentInstances)
            {
                if (ei.getEquipmentId() == equipmentId)
                    result.Add(ei);
            }
            return result;
        }

        public static List<EquipmentInstance> getAvailableInstancesByEquipmentId(int equipmentId)
        {
            List<EquipmentInstance> result = new List<EquipmentInstance>();
            foreach (EquipmentInstance ei in Program.EquipmentInstances)
            {
                if (ei.getEquipmentId() == equipmentId && ei.getStatus().ToLower() == "available")
                    result.Add(ei);
            }
            return result;
        }
    }
}
