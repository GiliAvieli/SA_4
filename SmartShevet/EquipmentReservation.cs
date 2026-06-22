using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public class EquipmentReservation
    {
        private int equipmentreservationId;
        private string reservationStatus;
        private DateTime requestDate;
        private DateTime activityDate;
        private int requestedById;

        public EquipmentReservation(int id, string reservationStatus, DateTime requestDate, DateTime activityDate,
                                   int requestedById, bool is_new)
        {
            this.equipmentreservationId = id;
            this.reservationStatus = reservationStatus;
            this.requestDate = requestDate;
            this.activityDate = activityDate;
            this.requestedById = requestedById;

            if (is_new)
            {
                this.createEquipmentReservation();
                Program.EquipmentReservations.Add(this);
            }
        }

        public int getId() { return this.equipmentreservationId; }
        public string getReservationStatus() { return this.reservationStatus; }
        public DateTime getRequestDate() { return this.requestDate; }
        public DateTime getActivityDate() { return this.activityDate; }
        public int getRequestedById() { return this.requestedById; }

        public void setReservationStatus(string reservationStatus) { this.reservationStatus = reservationStatus; }
        public void setRequestDate(DateTime requestDate) { this.requestDate = requestDate; }
        public void setActivityDate(DateTime activityDate) { this.activityDate = activityDate; }
        public void setRequestedById(int requestedById) { this.requestedById = requestedById; }

        public SeniorScout getRequestedBy()
        {
            return SeniorScout.seekSeniorScout(this.requestedById);
        }

        public void createEquipmentReservation()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentreservation_create @equipmentreservation_id, @reservationStatus, @requestDate, @activityDate, @requestedById";
            cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
            cmd.Parameters.AddWithValue("@reservationStatus", this.reservationStatus);
            cmd.Parameters.AddWithValue("@requestDate", this.requestDate);
            cmd.Parameters.AddWithValue("@activityDate", this.activityDate);
            cmd.Parameters.AddWithValue("@requestedById", this.requestedById);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateEquipmentReservation()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentreservation_update @equipmentreservation_id, @reservationStatus, @requestDate, @activityDate, @requestedById";
            cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
            cmd.Parameters.AddWithValue("@reservationStatus", this.reservationStatus);
            cmd.Parameters.AddWithValue("@requestDate", this.requestDate);
            cmd.Parameters.AddWithValue("@activityDate", this.activityDate);
            cmd.Parameters.AddWithValue("@requestedById", this.requestedById);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteEquipmentReservation()
        {
            Program.EquipmentReservations.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentreservation_delete @equipmentreservation_id";
            cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public static void initEquipmentReservations()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_equipmentreservation_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.EquipmentReservations = new List<EquipmentReservation>();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string reservationStatus = rdr.GetString(1);
                DateTime requestDate = rdr.GetDateTime(2);
                DateTime activityDate = rdr.GetDateTime(3);
                int requestedById = rdr.GetInt32(4);

                EquipmentReservation er = new EquipmentReservation(id, reservationStatus, requestDate, activityDate, requestedById, false);
                Program.EquipmentReservations.Add(er);
            }
        }

        public static EquipmentReservation seekEquipmentReservation(int id)
        {
            foreach (EquipmentReservation er in Program.EquipmentReservations)
            {
                if (er.getId() == id)
                    return er;
            }
            return null;
        }

        public static int getNextEquipmentReservationId()
        {
            if (Program.EquipmentReservations.Count == 0)
                return 1;

            int maxId = 0;
            foreach (EquipmentReservation er in Program.EquipmentReservations)
            {
                if (er.getId() > maxId)
                    maxId = er.getId();
            }
            return maxId + 1;
        }

        // =====================================================================
        // STATE MACHINE TRANSITIONS
        // =====================================================================

        public void approveReservation()
        {
            if (this.reservationStatus != "pending")
                throw new InvalidOperationException("לא ניתן לאשר הזמנה שאינה בהמתנה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentreservation_approve @equipmentreservation_id";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.reservationStatus = "approved";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה באישור הזמנה: {ex.Message}");
            }
        }

        public void denyReservation()
        {
            if (this.reservationStatus != "pending")
                throw new InvalidOperationException("לא ניתן לדחות הזמנה שאינה בהמתנה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentreservation_deny @equipmentreservation_id";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.reservationStatus = "denied";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בדחיית הזמנה: {ex.Message}");
            }
        }

        public void cancelReservation()
        {
            if (this.reservationStatus != "pending" && this.reservationStatus != "approved")
                throw new InvalidOperationException("לא ניתן לבטל הזמנה בסטטוס זה");

            if (this.reservationStatus == "approved" && DateTime.Now >= this.activityDate)
                throw new InvalidOperationException("לא ניתן לבטל הזמנה לאחר תאריך הפעילות");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentreservation_cancel @equipmentreservation_id";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.reservationStatus = "cancelled";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בביטול הזמנה: {ex.Message}");
            }
        }

        public void activateReservation()
        {
            if (this.reservationStatus != "approved")
                throw new InvalidOperationException("לא ניתן להפעיל הזמנה שאינה מאושרת");

            if (DateTime.Now < this.activityDate.Date)
                throw new InvalidOperationException($"לא ניתן להפעיל הזמנה לפני {this.activityDate:yyyy-MM-dd}");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentreservation_activate @equipmentreservation_id";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.reservationStatus = "active";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בהפעלת הזמנה: {ex.Message}");
            }
        }

        public void closeReservation()
        {
            if (this.reservationStatus != "active")
                throw new InvalidOperationException("לא ניתן לסגור הזמנה שאינה פעילה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentreservation_close @equipmentreservation_id";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.reservationStatus = "completed";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בסגירת הזמנה: {ex.Message}");
            }
        }

        public void partialReturn()
        {
            if (this.reservationStatus != "active")
                throw new InvalidOperationException("לא ניתן להקליט החזרה חלקית להזמנה שאינה פעילה");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentreservation_partial_return @equipmentreservation_id";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.reservationStatus = "completed";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בהקלטת החזרה חלקית: {ex.Message}");
            }
        }

        public void resubmitReservation()
        {
            if (this.reservationStatus != "denied")
                throw new InvalidOperationException("לא ניתן להגיש מחדש הזמנה שאינה נדחית");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_equipmentreservation_resubmit @equipmentreservation_id";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", this.equipmentreservationId);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);
                this.reservationStatus = "pending";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בהגשה מחדש של הזמנה: {ex.Message}");
            }
        }

        // =====================================================================
        // COMPLEX FLOW: RESERVE EQUIPMENT (UC3)
        // =====================================================================
        // Domain verb method that orchestrates the entire reservation flow atomically:
        // 1. Calls sp_reserve_equipment (single transaction in DB)
        // 2. Updates all in-memory lists (EquipmentReservation, Equipment, ReservationDetails)
        // 3. Surfaces errors as Hebrew messages to UI

        public static EquipmentReservation reserveEquipment(
            DateTime requestDate,
            DateTime activityDate,
            int requestedById,
            List<(int equipmentId, int quantity)> items)
        {
            try
            {
                // Get next reservation ID
                int newId = getNextEquipmentReservationId();

                // Build JSON items array for SP
                System.Text.StringBuilder jsonBuilder = new System.Text.StringBuilder("[");
                for (int i = 0; i < items.Count; i++)
                {
                    if (i > 0) jsonBuilder.Append(",");
                    jsonBuilder.Append($"{{\"equipmentId\":{items[i].equipmentId},\"quantity\":{items[i].quantity}}}");
                }
                jsonBuilder.Append("]");
                string itemsJson = jsonBuilder.ToString();

                // Call sp_reserve_equipment via SQL_CON
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_reserve_equipment @equipmentreservation_id, @requestDate, @activityDate, @requestedById, @itemsJson";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", newId);
                cmd.Parameters.AddWithValue("@requestDate", requestDate);
                cmd.Parameters.AddWithValue("@activityDate", activityDate);
                cmd.Parameters.AddWithValue("@requestedById", requestedById);
                cmd.Parameters.AddWithValue("@itemsJson", itemsJson);
                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);

                // =====================================================================
                // ATOMIC SP succeeded — update in-memory state
                // =====================================================================

                // Step 1: Create and add EquipmentReservation to in-memory list
                EquipmentReservation newReservation = new EquipmentReservation(
                    newId,
                    "Approved",
                    requestDate,
                    activityDate,
                    requestedById,
                    false);  // is_new=false: already in DB
                Program.EquipmentReservations.Add(newReservation);

                // Step 2: Update Equipment objects in memory (set status to 'reserved')
                foreach (var item in items)
                {
                    Equipment eq = Equipment.seekEquipment(item.equipmentId);
                    if (eq != null)
                    {
                        eq.setStatus("reserved");
                        eq.setLastUpdated(DateTime.Now);
                    }
                }

                // Step 3: Create and add ReservationDetails to in-memory list
                int nextDetailsId = 1;
                if (Program.ReservationDetailsList.Count > 0)
                {
                    int maxDetailsId = 0;
                    foreach (ReservationDetails rd in Program.ReservationDetailsList)
                    {
                        if (rd.getId() > maxDetailsId)
                            maxDetailsId = rd.getId();
                    }
                    nextDetailsId = maxDetailsId + 1;
                }

                for (int i = 0; i < items.Count; i++)
                {
                    ReservationDetails rd = new ReservationDetails(
                        nextDetailsId + i,
                        i + 1,  // entry number
                        items[i].quantity,
                        items[i].equipmentId,
                        newId,  // equipmentreservation_id
                        false,  // addedEquipment = false
                        false); // is_new = false (already persisted by SP)
                    Program.ReservationDetailsList.Add(rd);
                }

                return newReservation;
            }
            catch (Exception ex)
            {
                // Surface SP error message as Hebrew string to UI
                throw new InvalidOperationException($"שגיאה בהזמנת ציוד: {ex.Message}");
            }
        }
    }
}
