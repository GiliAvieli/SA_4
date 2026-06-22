USE SmartShevet;

-- ============================================================================
-- LOAD ORDER:
-- 1. Equipment (base, no FK)
-- 2. SeniorScout (base, no FK)
-- 3. WarehouseStaffMember (subclass of SeniorScout)
-- 4. SeniorCoordinator (subclass of SeniorScout)
-- 5. EquipmentReservation (FK to SeniorScout)
-- 6. EquipmentIssue (FK to Equipment, SeniorScout, EquipmentReservation)
-- 7. ReservationDetails (association, FK to Equipment, EquipmentReservation)
-- ============================================================================

-- ============================================================================
-- EQUIPMENT TABLE - Real inventory from warehouse
-- ============================================================================

-- Craft Container (מכולת יצירה) - Fabric & Felt Items
INSERT INTO Equipment (equipment_id, name, category, description, equipmentType, containerType, quantity, minimumQuantity, status, lastUpdated, notes)
VALUES
(1, N'בד צהוב - גליל', N'בדים', N'בד צהוב לפעילויות יצירה', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(2, N'בד כחול - גליל', N'בדים', N'בד כחול לפעילויות יצירה', N'consumable', N'craft', 2, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(3, N'בד כחול - כדור גדול', N'בדים', N'בד כחול כדור גדול', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(4, N'בד כחול - כדור קטן', N'בדים', N'בד כחול כדור קטן', N'consumable', N'craft', 4, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(5, N'בד לבן - גליל', N'בדים', N'בד לבן לפעילויות יצירה', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(6, N'בד לבן - כדור קטן', N'בדים', N'בד לבן כדור קטן', N'consumable', N'craft', 0, NULL, N'lost', GETDATE(), N'חסר מהמחסן'),
(7, N'בד אדום - גליל', N'בדים', N'בד אדום לפעילויות יצירה', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(8, N'בד אפור - כדור קטן', N'בדים', N'בד אפור כדור קטן', N'consumable', N'craft', 0, NULL, N'lost', GETDATE(), N'חסר מהמחסן'),
(9, N'אלבד שחור - גליל', N'אלבד', N'אלבד שחור - גליל', N'consumable', N'craft', 0, NULL, N'lost', GETDATE(), N'חסר מהמחסן'),
(10, N'אלבד תכלת - גליל', N'אלבד', N'אלבד תכלת - גליל', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(11, N'אלבד חום - גליל', N'אלבד', N'אלבד חום - גליל', N'consumable', N'craft', 2, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(12, N'אלבד צהוב - גליל', N'אלבד', N'אלבד צהוב - גליל', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(13, N'אלבד סגול - גליל', N'אלבד', N'אלבד סגול - גליל', N'consumable', N'craft', 4, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(14, N'אלבד ירוק - גליל', N'אלבד', N'אלבד ירוק - גליל', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(15, N'אלבד אדום - גליל', N'אלבד', N'אלבד אדום - גליל', N'consumable', N'craft', 7, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(16, N'אלבד אפור - גליל', N'אלבד', N'אלבד אפור - גליל', N'consumable', N'craft', 2, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(17, N'אלבד אפור - כדור', N'אלבד', N'אלבד אפור - כדור', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(18, N'אלבד כחול - גליל', N'אלבד', N'אלבד כחול - גליל', N'consumable', N'craft', 3, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(19, N'אלבד כחול - כדור', N'אלבד', N'אלבד כחול - כדור', N'consumable', N'craft', 3, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(20, N'אלבד ורוד - גליל', N'אלבד', N'אלבד ורוד - גליל', N'consumable', N'craft', 0, NULL, N'lost', GETDATE(), N'חסר מהמחסן'),
(21, N'אלבד ורוד - כדור', N'אלבד', N'אלבד ורוד - כדור', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(22, N'אלבד כתום - גליל', N'אלבד', N'אלבד כתום - גליל', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),

-- Art Supplies
(23, N'מכחולים', N'ציוד יצירה', N'מכחולים לציור וכתיבה', N'reusable', N'craft', 12, 10, N'available', GETDATE(), N'נמצא במחסן יצירה'),
(24, N'לקים', N'ציוד יצירה', N'לקים צבעוניים לפעילויות', N'reusable', N'craft', 30, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(25, N'קאטרים', N'ציוד יצירה', N'קאטרים צבעוניים לציור', N'reusable', N'craft', 4, 10, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(26, N'מחברות', N'ציוד כתיבה', N'מחברות לרישום וכתיבה', N'consumable', N'craft', 45, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(27, N'דפים', N'ציוד כתיבה', N'דפים לציור וכתיבה', N'consumable', N'craft', 6, 2, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(28, N'בריסטולים', N'ציוד בריסטול', N'דפי בריסטול לפעילויות', N'consumable', N'craft', 1, 4, N'underRepair', GETDATE(), N'חסר במלאי, הזמנה בהכנה'),
(29, N'רצועות בד', N'אביזרים', N'רצועות בד לתפירה', N'consumable', N'craft', 1, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(30, N'נצנצים', N'אביזרים', N'נצנצים בכל הצבעים', N'consumable', N'craft', 30, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(31, N'סלוטייפ', N'אביזרים', N'סלוטייפ לדבקה', N'consumable', N'craft', 50, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(32, N'טושים', N'ציוד כתיבה', N'טושים צבעוניים', N'reusable', N'craft', 25, 20, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(33, N'מספריים', N'כלים', N'מספריים לגזירה', N'reusable', N'craft', 4, 5, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(34, N'זרנוקים', N'אביזרים', N'זרנוקים מצינור', N'reusable', N'craft', 11, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(35, N'מכשירי קשר', N'אביזרים', N'מכשירי קשר (וקי-טוקי)', N'reusable', N'craft', 9, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(36, N'מפות', N'אביזרים', N'מפות לפעילויות חוצות', N'reusable', N'craft', 7, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(37, N'ססלים', N'אביזרים', N'ססלים לאחסון', N'consumable', N'craft', 30, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(38, N'עזרה ראשונה - תיק גדול', N'רפואה', N'ערכת עזרה ראשונה גדולה', N'reusable', N'craft', 3, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(39, N'עזרה ראשונה - תיק קטן', N'רפואה', N'ערכת עזרה ראשונה קטנה', N'reusable', N'craft', 3, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(40, N'שאקלים', N'אביזרים', N'שאקלים לשקילה', N'reusable', N'craft', 13, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(41, N'צמר פלדה', N'אביזרים', N'צמר פלדה לניקוי', N'consumable', N'craft', 3, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(42, N'כפפות בישול', N'אביזרים', N'כפפות בישול לחוצה בר', N'reusable', N'craft', 20, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),
(43, N'שיפודים', N'ציוד בישול', N'שיפודים לגריל', N'consumable', N'craft', 2, NULL, N'available', GETDATE(), N'מחסן מכולת יצירה'),

-- Kitchen Container (מכולת מטבח)
(44, N'תרמוקן 48 ליטר', N'מטבח', N'תרמוקן גדול להחזקת טמפרטורה', N'reusable', N'kitchen', 1, NULL, N'available', GETDATE(), N'מחסן מכולת מטבח'),
(45, N'תרמוקן 43 ליטר', N'מטבח', N'תרמוקן להחזקת טמפרטורה', N'reusable', N'kitchen', 4, NULL, N'available', GETDATE(), N'מחסן מכולת מטבח'),
(46, N'תרמוקן 38 ליטר', N'מטבח', N'תרמוקן להחזקת טמפרטורה', N'reusable', N'kitchen', 3, NULL, N'available', GETDATE(), N'מחסן מכולת מטבח'),
(47, N'תרמוקן 20 ליטר', N'מטבח', N'תרמוקן קטן להחזקת טמפרטורה', N'reusable', N'kitchen', 1, NULL, N'available', GETDATE(), N'מחסן מכולת מטבח'),
(48, N'צידנית גדולה', N'מטבח', N'צידנית להחזקת קור', N'reusable', N'kitchen', 2, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(49, N'סיר גדול צליאק', N'מטבח', N'סיר בישול גדול', N'reusable', N'kitchen', 3, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(50, N'סיר בינוני צליאק', N'מטבח', N'סיר בישול בינוני', N'reusable', N'kitchen', 1, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(51, N'סיר קטן צליאק', N'מטבח', N'סיר בישול קטן', N'reusable', N'kitchen', 2, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(52, N'מכסה סיר גדול צליאק', N'מטבח', N'מכסה לסיר גדול', N'reusable', N'kitchen', 2, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(53, N'מכסה סיר בינוני צליאק', N'מטבח', N'מכסה לסיר בינוני', N'reusable', N'kitchen', 1, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(54, N'מסננות צליאק', N'מטבח', N'מסננות למים', N'reusable', N'kitchen', 2, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(55, N'גסטרונום גדול צליאק', N'מטבח', N'מכל אחסון אוכל גדול', N'reusable', N'kitchen', 2, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(56, N'גסטרונום בינוני צליאק', N'מטבח', N'מכל אחסון אוכל בינוני', N'reusable', N'kitchen', 2, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(57, N'גסטרונום קטן צליאק', N'מטבח', N'מכל אחסון אוכל קטן', N'reusable', N'kitchen', 2, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(58, N'קרש חיתוך צליאק', N'מטבח', N'קרש חיתוך נקי אחסון', N'reusable', N'kitchen', 26, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(59, N'כפות הגשה צליאק', N'מטבח', N'כפות להגשה', N'reusable', N'kitchen', 32, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(60, N'פחים', N'מטבח', N'פחים להשלכה אשפה', N'reusable', N'kitchen', 8, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(61, N'דליים', N'מטבח', N'דליים לנקיון', N'reusable', N'kitchen', 4, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(62, N'גיגיות', N'מטבח', N'גיגיות להגשה', N'reusable', N'kitchen', 6, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(63, N'שולחנות נפתחים', N'מטבח', N'שולחנות לאירוח מחנות', N'reusable', N'kitchen', 5, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(64, N'מכסי פחים', N'מטבח', N'מכסים לפחים', N'reusable', N'kitchen', 5, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(65, N'אלונקה', N'מטבח', N'אלונקה לשטיפה', N'reusable', N'kitchen', 4, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(66, N'משפכים', N'מטבח', N'משפכים להעברת חומרים', N'reusable', N'kitchen', 16, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(67, N'סבונים', N'מטבח', N'סבונים לניקוי', N'consumable', N'kitchen', 8, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(68, N'פוליטילן', N'מטבח', N'פוליטילן גליל', N'consumable', N'kitchen', 2, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(69, N'תוכים', N'מטבח', N'תוכים לטבילת כלים', N'reusable', N'kitchen', 8, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(70, N'מסורים', N'מטבח', N'מסורים לחיתוך', N'reusable', N'kitchen', 5, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(71, N'אלמניות', N'מטבח', N'אלמניות לבישול', N'reusable', N'kitchen', 5, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(72, N'קרשי חיתוך', N'מטבח', N'קרשי חיתוך מעץ', N'reusable', N'kitchen', 18, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(73, N'מסננת גדולה', N'מטבח', N'מסננת למים וביצים', N'reusable', N'kitchen', 3, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(74, N'מסננת קטנה', N'מטבח', N'מסננת קטנה', N'reusable', N'kitchen', 4, NULL, N'available', GETDATE(), N'מחסן מטבח'),
(75, N'מועכי פירה', N'מטבח', N'מעיכות לפירה', N'reusable', N'kitchen', 5, NULL, N'available', GETDATE(), N'מחסן מטבח'),

-- Camp Container (מכולת מחנק / מכולת מפעלים)
(76, N'ג''ריקן 10 ליטר', N'מחנה', N'ג''ריקן גדול למים', N'reusable', N'camp', 18, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(77, N'ג''ריקן 5 ליטר', N'מחנה', N'ג''ריקן בינוני למים', N'reusable', N'camp', 13, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(78, N'ג''ריקן 4 ליטר', N'מחנה', N'ג''ריקן קטן למים', N'reusable', N'camp', 14, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(79, N'תיקי ג''ריקן', N'מחנה', N'תיקים להנשאת ג''ריקנים', N'reusable', N'camp', 5, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(80, N'חבל יתר - שקיות', N'רשת', N'חבל לתליה ורישוט', N'consumable', N'camp', 4, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(81, N'חבלי כפיתה - באלה', N'רשת', N'חבלים לכפיפה', N'consumable', N'camp', 22, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(82, N'חבלי כפיתה - שקיות', N'רשת', N'חבלים לכפיפה - שקיות', N'consumable', N'camp', 6, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(83, N'חבל סיירים', N'רשת', N'חבלים לפעילויות סיירים', N'consumable', N'camp', 2, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(84, N'חבל 6 - באלה', N'רשת', N'חבל קוטר 6 מ''מ', N'consumable', N'camp', 1, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(85, N'חבל לקשירה - באלה', N'רשת', N'חבלים לקשירה כללית', N'consumable', N'camp', 12, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(86, N'חבל סיזל 4 - באלה', N'רשת', N'חבל סיזל קוטר 4 מ''מ', N'consumable', N'camp', 4, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(87, N'חבל סיזל 8 - באלה', N'רשת', N'חבל סיזל קוטר 8 מ''מ', N'consumable', N'camp', 1, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(88, N'גרילנדות', N'תאורה', N'גרילנדות חשמליות למאורות', N'reusable', N'camp', 4, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(89, N'נורות 11W', N'תאורה', N'נורות 11 ואט', N'consumable', N'camp', 5, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(90, N'נורות - יחידות', N'תאורה', N'נורות יחידות', N'consumable', N'camp', 20, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(91, N'נורות (אולי עובדות)', N'תאורה', N'נורות שקולות להעברה', N'consumable', N'camp', 20, NULL, N'underRepair', GETDATE(), N'בודקים תפקוד'),
(92, N'פרוז''קטורים', N'תאורה', N'פרוז''קטורים למאורות מחנות', N'reusable', N'camp', 8, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(93, N'ספוגים לסנדות', N'אביזרים', N'ספוגים לתיקיות שינה', N'consumable', N'camp', 50, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(94, N'קיפרים', N'אביזרים', N'קיפרים לדיגים', N'reusable', N'camp', 300, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(95, N'ערכות עלייה לגובה', N'ציוד בטיחות', N'ערכות בטיחות לעלייה', N'reusable', N'camp', 18, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),

-- Tents & Structures
(96, N'שוקת', N'אוהלים', N'שוקת מתכת למטהו', N'reusable', N'camp', 2, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(97, N'אוהל 11 איש', N'אוהלים', N'אוהל שדה לחיילים', N'reusable', N'camp', 3, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(98, N'חיבורים אוהל 11 - קיט', N'אוהלים', N'חיבורים ותיקיות לאוהל', N'reusable', N'camp', 3, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(99, N'גזייה 3 ראשים', N'ביישול', N'גזייה תלת-ראשים', N'reusable', N'camp', 1, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(100, N'גזייה 2 ראשים', N'ביישול', N'גזייה דו-ראשית', N'reusable', N'camp', 4, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(101, N'כלב גז', N'ביישול', N'בקבוקי גז לגזייה', N'consumable', N'camp', 3, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(102, N'כיור', N'אביזרים', N'כיור נייד לשטיפה', N'reusable', N'camp', 1, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(103, N'כיריים', N'ביישול', N'כיריים חשמליות', N'reusable', N'camp', 3, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(104, N'מיטות שדה', N'שינה', N'מיטות קמפינג נישאות', N'reusable', N'camp', 4, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(105, N'צינור ניקוז לבן', N'אביזרים', N'צינורות ניקוז אוהלים', N'reusable', N'camp', 2, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(106, N'יוטה', N'אביזרים', N'יוטה לבנייה מטהו', N'reusable', N'camp', 3, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(107, N'טאבון', N'ביישול', N'תנור קמפינג לביישול', N'reusable', N'camp', 1, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(108, N'מחברים צינורות - ארגז', N'אביזרים', N'מחברי צינורות באריזה', N'reusable', N'camp', 1, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(109, N'פלנצה', N'אביזרים', N'פלנצות למטהו', N'reusable', N'camp', 2, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(110, N'ציליות', N'שינה', N'כריות שינה לטיולים', N'reusable', N'camp', 11, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(111, N'מאווררים', N'אביזרים', N'מאווררים לאוהלים', N'reusable', N'camp', 6, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(112, N'חבד - באלה', N'רשת', N'חבד לבנייה מטהו', N'consumable', N'camp', 7, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),
(113, N'חבע - באלה', N'רשת', N'חבע לבנייה מטהו', N'consumable', N'camp', 9, NULL, N'available', GETDATE(), N'מחסן מכולת מחנה'),

-- Food & Consumables (Small Kitchen Storage)
(114, N'אפונה 300ג', N'מזון', N'אפונה מומשה', N'consumable', N'kitchen', 148, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(115, N'שעועית 550ג', N'מזון', N'שעועית טבעית', N'consumable', N'kitchen', 12, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(116, N'רוטב עגבניות 260ג', N'מזון', N'רוטב עגבניות מרוכז', N'consumable', N'kitchen', 18, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(117, N'תירס 2 קילו', N'מזון', N'תירס טרי קפוא', N'consumable', N'kitchen', 9, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(118, N'ספגטי 5 קילו', N'מזון', N'פסטה ספגטי', N'consumable', N'kitchen', 3, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(119, N'רסק עגבניות 2.6 קילו', N'מזון', N'רסק עגבניות טבעי', N'consumable', N'kitchen', 6, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(120, N'שחר חלבי 1 קילו', N'מזון', N'שחר חלבי טבעי', N'consumable', N'kitchen', 16, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(121, N'שחר חלבי 600ג', N'מזון', N'שחר חלבי באריזה קטנה', N'consumable', N'kitchen', 95, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(122, N'שחר פרווה 400ג', N'מזון', N'שחר פרווה קלוי', N'consumable', N'kitchen', 1, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(123, N'אפונה וגזר 500ג', N'מזון', N'תערובת אפונה וגזר', N'consumable', N'kitchen', 12, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(124, N'זיתים 500ג', N'מזון', N'זיתים שחורים', N'consumable', N'kitchen', 55, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(125, N'פתיבר 200ג', N'מזון', N'פתיבר (בולגור)', N'consumable', N'kitchen', 35, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(126, N'גרגירי חומוס 550ג', N'מזון', N'חומוס יבש', N'consumable', N'kitchen', 29, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(127, N'קטשופ 750ג', N'מזון', N'קטשופ כללי', N'consumable', N'kitchen', 9, NULL, N'available', GETDATE(), N'מחסן מזון קטן'),
(128, N'שמן קנולה 1 ליטר', N'מזון', N'שמן קנולה מזוקק', N'consumable', N'kitchen', 0, NULL, N'lost', GETDATE(), N'חסר מהמחסן'),
(129, N'תיונים', N'מזון', N'תיונים מיובשים', N'consumable', N'kitchen', 2000, NULL, N'available', GETDATE(), N'מחסן מזון קטן');

-- ============================================================================
-- SENIORSCOUT TABLE - Realistic Hebrew names covering all roles
-- ============================================================================

INSERT INTO SeniorScout (seniorscout_id, name, grade, role, email, phoneNumber, password)
VALUES
(1, N'דור משה', N'11th Grade', N'guide', N'dor.moshe@shevet.org.il', N'050-1234567', N'password123'),
(2, N'אוריאל כהן', N'12th Grade', N'seniorCoordinator', N'uriel.cohen@shevet.org.il', N'052-7654321', N'password123'),
(3, N'טלי רוביין', N'10th Grade', N'logisticsTeamMember', N'tali.rubin@shevet.org.il', N'050-2222222', N'password123'),
(4, N'עמרי לוי', N'11th Grade', N'guide', N'amri.levy@shevet.org.il', N'052-3333333', N'password123'),
(5, N'שיר הלל', N'9th Grade', N'operationsTeamMember', N'shir.hallel@shevet.org.il', N'050-4444444', N'password123'),
(6, N'עומר גבעון', N'10th Grade', N'logisticsTeamMember', N'omer.givaon@shevet.org.il', N'052-5555555', N'password123'),
(7, N'מיכל קרנית', N'11th Grade', N'prideTeamMember', N'michal.karnit@shevet.org.il', N'050-6666666', N'password123'),
(8, N'אדם ברקוביץ', N'12th Grade', N'troopLeader', N'adam.berkowitz@shevet.org.il', N'052-7777777', N'password123'),
(9, N'ליאור מוביוס', N'10th Grade', N'communityTeamMember', N'lior.mobius@shevet.org.il', N'050-8888888', N'password123'),
(10, N'יהונתן שפיר', N'9th Grade', N'juniorCoordinator', N'yehonatan.shapir@shevet.org.il', N'052-9999999', N'password123'),
(11, N'רות גלבוע', N'11th Grade', N'scoutingTeamMember', N'ruth.gelboe@shevet.org.il', N'050-1111111', N'password123'),
(12, N'ניסים כהן', N'10th Grade', N'shevetTeamMember', N'nissim.cohen@shevet.org.il', N'052-2222222', N'password123');

-- ============================================================================
-- WAREHOUSESTAFFMEMBER TABLE - Subclass instances
-- ============================================================================

INSERT INTO WarehouseStaffMember (warehousestaffmember_id)
VALUES (3), (6);

-- ============================================================================
-- SENIORCOORDINATOR TABLE - Subclass instance
-- ============================================================================

INSERT INTO SeniorCoordinator (seniorcoordinator_id)
VALUES (2);

-- ============================================================================
-- EQUIPMENTRESERVATION TABLE - Various status values
-- ============================================================================

INSERT INTO EquipmentReservation (equipmentreservation_id, reservationStatus, requestDate, activityDate, requestedById)
VALUES
(1, N'approved', '2026-06-15 10:30:00', '2026-07-01 09:00:00', 1),
(2, N'inProcess', '2026-06-20 14:00:00', '2026-07-05 10:00:00', 4),
(3, N'completed', '2026-06-10 11:15:00', '2026-06-22 15:00:00', 7),
(4, N'pendingApproval', '2026-06-21 16:45:00', '2026-07-10 09:00:00', 9),
(5, N'rejected', '2026-06-18 09:00:00', '2026-07-08 14:00:00', 5),
(6, N'needsModification', '2026-06-19 13:20:00', '2026-07-06 10:30:00', 11),
(7, N'cancelled', '2026-06-17 10:10:00', '2026-07-03 11:00:00', 12),
(8, N'issued', '2026-06-21 15:00:00', '2026-06-25 08:00:00', 1),
(9, N'approved', '2026-06-22 08:30:00', '2026-06-28 10:00:00', 4),
(10, N'inProcess', '2026-06-22 12:00:00', '2026-07-02 14:00:00', 7);

-- ============================================================================
-- EQUIPMENTISSUE TABLE - Various conditions and statuses
-- ============================================================================

INSERT INTO EquipmentIssue (equipmentissue_id, issueDate, returnDate, equipmentId, issuedToId, reservationId, status, condition)
VALUES
(1, '2026-06-15 09:00:00', '2026-06-22 17:00:00', 1, 1, 1, N'returned', N'good'),
(2, '2026-06-16 10:30:00', NULL, 44, 4, 2, N'issued', N'good'),
(3, '2026-06-10 08:00:00', '2026-06-22 16:30:00', 23, 7, 3, N'returned', N'damaged'),
(4, '2026-06-19 14:15:00', NULL, 76, 9, 4, N'issued', N'good'),
(5, '2026-06-18 11:00:00', '2026-06-21 15:45:00', 32, 5, 5, N'returned', N'good'),
(6, '2026-06-17 13:30:00', NULL, 88, 11, 6, N'partially_returned', N'good'),
(7, '2026-06-14 09:45:00', '2026-06-20 18:00:00', 97, 12, 7, N'returned', N'missing'),
(8, '2026-06-21 15:00:00', NULL, 24, 1, 8, N'issued', N'good'),
(9, '2026-06-22 08:30:00', NULL, 45, 4, 9, N'issued', N'good'),
(10, '2026-06-20 16:00:00', '2026-06-22 14:00:00', 58, 7, 10, N'returned', N'good');

-- ============================================================================
-- RESERVATIONDETAILS TABLE - Association class linking reservations to equipment
-- ============================================================================

INSERT INTO ReservationDetails (reservationdetails_id, entry, quantity, equipmentId, equipmentreservation_id, addedEquipment)
VALUES
(1, 1, 1, 1, 1, 0),
(2, 2, 2, 23, 1, 0),
(3, 1, 4, 44, 2, 0),
(4, 2, 1, 45, 2, 1),
(5, 1, 3, 23, 3, 0),
(6, 2, 1, 76, 3, 0),
(7, 1, 2, 88, 4, 0),
(8, 1, 1, 32, 5, 0),
(9, 2, 2, 24, 5, 1),
(10, 1, 5, 45, 6, 0),
(11, 2, 1, 97, 6, 0),
(12, 1, 4, 58, 7, 0),
(13, 2, 2, 76, 7, 1),
(14, 1, 1, 1, 8, 0),
(15, 2, 3, 23, 8, 0),
(16, 1, 2, 44, 9, 0),
(17, 1, 1, 88, 10, 0),
(18, 2, 2, 58, 10, 1);
