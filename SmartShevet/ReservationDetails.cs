using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public class ReservationDetails
    {
        private int reservationdetailsId;
        private int entry;
        private int quantity;
        private Equipment equipment;
        private EquipmentReservation reservation;
        private bool addedEquipment;

        public ReservationDetails(int id, int entry, int quantity, int equipmentId, int reservationId,
                                 bool addedEquipment, bool is_new)
        {
            this.reservationdetailsId = id;
            this.entry = entry;
            this.quantity = quantity;
            this.equipment = Equipment.seekEquipment(equipmentId);
            this.reservation = EquipmentReservation.seekEquipmentReservation(reservationId);
            this.addedEquipment = addedEquipment;

            if (is_new)
            {
                this.createReservationDetails();
                Program.ReservationDetailsList.Add(this);
            }
        }

        public int getId() { return this.reservationdetailsId; }
        public int getEntry() { return this.entry; }
        public int getQuantity() { return this.quantity; }
        public Equipment getEquipment() { return this.equipment; }
        public EquipmentReservation getReservation() { return this.reservation; }
        public bool getAddedEquipment() { return this.addedEquipment; }

        public void setEntry(int entry) { this.entry = entry; }
        public void setQuantity(int quantity) { this.quantity = quantity; }
        public void setEquipment(Equipment equipment) { this.equipment = equipment; }
        public void setReservation(EquipmentReservation reservation) { this.reservation = reservation; }
        public void setAddedEquipment(bool addedEquipment) { this.addedEquipment = addedEquipment; }

        public void createReservationDetails()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_reservationdetails_create @reservationdetails_id, @entry, @quantity, @equipmentId, @equipmentreservation_id, @addedEquipment";
            cmd.Parameters.AddWithValue("@reservationdetails_id", this.reservationdetailsId);
            cmd.Parameters.AddWithValue("@entry", this.entry);
            cmd.Parameters.AddWithValue("@quantity", this.quantity);
            cmd.Parameters.AddWithValue("@equipmentId", this.equipment?.getId() ?? 0);
            cmd.Parameters.AddWithValue("@equipmentreservation_id", this.reservation?.getId() ?? 0);
            cmd.Parameters.AddWithValue("@addedEquipment", this.addedEquipment ? 1 : 0);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateReservationDetails()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_reservationdetails_update @reservationdetails_id, @entry, @quantity, @equipmentId, @equipmentreservation_id, @addedEquipment";
            cmd.Parameters.AddWithValue("@reservationdetails_id", this.reservationdetailsId);
            cmd.Parameters.AddWithValue("@entry", this.entry);
            cmd.Parameters.AddWithValue("@quantity", this.quantity);
            cmd.Parameters.AddWithValue("@equipmentId", this.equipment?.getId() ?? 0);
            cmd.Parameters.AddWithValue("@equipmentreservation_id", this.reservation?.getId() ?? 0);
            cmd.Parameters.AddWithValue("@addedEquipment", this.addedEquipment ? 1 : 0);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteReservationDetails()
        {
            Program.ReservationDetailsList.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_reservationdetails_delete @reservationdetails_id";
            cmd.Parameters.AddWithValue("@reservationdetails_id", this.reservationdetailsId);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public static void initReservationDetails()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_reservationdetails_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.ReservationDetailsList = new List<ReservationDetails>();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                int entry = rdr.GetInt32(1);
                int quantity = rdr.GetInt32(2);
                int equipmentId = rdr.GetInt32(3);
                int reservationId = rdr.GetInt32(4);
                bool addedEquipment = rdr.GetBoolean(5);

                ReservationDetails rd = new ReservationDetails(id, entry, quantity, equipmentId, reservationId, addedEquipment, false);
                Program.ReservationDetailsList.Add(rd);
            }
        }

        public static ReservationDetails seekReservationDetails(int id)
        {
            foreach (ReservationDetails rd in Program.ReservationDetailsList)
            {
                if (rd.getId() == id)
                    return rd;
            }
            return null;
        }

        public static int getNextReservationDetailsId()
        {
            if (Program.ReservationDetailsList.Count == 0)
                return 1;

            int maxId = 0;
            foreach (ReservationDetails rd in Program.ReservationDetailsList)
            {
                if (rd.getId() > maxId)
                    maxId = rd.getId();
            }
            return maxId + 1;
        }
    }
}
