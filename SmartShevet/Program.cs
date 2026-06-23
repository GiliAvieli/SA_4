using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartShevet
{
    static class Program
    {
        // =====================================================================
        // רשימות בזיכרון
        // רשימה סטטית לכל ישות (Entity) במערכת.
        // הרשימות נטענות מבסיס הנתונים בהפעלת התוכנית.
        //
        // שימו לב: אין רשימה נפרדת ל-WarehouseStaffMember ול-SeniorCoordinator!
        // הם יורשים מ-SeniorScout ולכן נכנסים לרשימות משלהם (פולימורפיזם).
        //
        // כשמוסיפים ישות חדשה:
        //   1. הוסיפו רשימה כאן
        //   2. כתבו מתודת init סטטית במחלקת ה-Entity
        //   3. קראו לה מ-initLists בסדר הנכון
        // =====================================================================

        public static List<Equipment> Equipments;
        public static List<EquipmentInstance> EquipmentInstances;
        public static List<SeniorScout> SeniorScouts;
        public static List<WarehouseStaffMember> WarehouseStaffMembers;
        public static List<SeniorCoordinator> SeniorCoordinators;
        public static List<EquipmentReservation> EquipmentReservations;
        public static List<EquipmentIssue> EquipmentIssues;
        public static List<ReservationDetails> ReservationDetailsList;

        // =====================================================================
        // Logged-in user tracking
        // =====================================================================
        public static int LoggedInUserId = 1;  // Track the authenticated user's ID

        // =====================================================================
        // אתחול כל הרשימות
        //
        // סדר הטעינה חשוב!
        //   1. קודם: ישויות בסיסיות (שאחרים מפנים אליהן)
        //   2. אחר כך: ישויות שמכילות Foreign Key
        //   3. אחרון: מחלקות קישור (שמפנות לשני צדדים)
        //
        // דוגמה: Equipment ו-SeniorScout חייבים להיטען לפני EquipmentReservation,
        //         ו-EquipmentReservation חייב להיטען לפני EquipmentIssue וReservationDetails.
        // =====================================================================

        public static void initLists()
        {
            Equipment.initEquipments();                    // 1. ציוד (בסיסי)
            EquipmentInstance.initEquipmentInstances();    // 2. יחידות ציוד בודדות לציוד הניתן לשימוש חוזר
            SeniorScout.initSeniorScouts();                // 3. סקאוט בכיר (בסיסי)
            WarehouseStaffMember.initWarehouseStaffMembers();  // 4. חברי צוות מחסן (יורשים מ-SeniorScout)
            SeniorCoordinator.initSeniorCoordinators();    // 5. קואורדינטור בכיר (יורשים מ-SeniorScout)
            EquipmentReservation.initEquipmentReservations();  // 6. הזמנות ציוד (FK ל-SeniorScout)
            EquipmentIssue.initEquipmentIssues();          // 7. בעיות ציוד (FK ל-Equipment, SeniorScout, EquipmentReservation)
            ReservationDetails.initReservationDetails();   // 8. פרטי הזמנה (association class)
        }

        // =====================================================================
        // נקודת ההתחלה של התוכנית
        // =====================================================================

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            initLists();
            Application.Run(new mainForm());
        }
    }
}
