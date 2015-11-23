using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KVrachu
{
    class UriStrings
    {
        // profile_id - Тип врача (Окулист, Педиатр и т.д.)
        // doctor_id  - код конкретного врача
        // hospital_id (=13003369 для Люберецкого района) - код региона
        // hospital_unit_id (=92 для нашей поликлиники) - код поликлиники

        public const string AdressStart = "http://mosreg.k-vrachu.ru/";

        public const string LoginFormatStr = "username={0}&password={1}&login-submit=%D0%92%D0%BE%D0%B9%D1%82%D0%B8";
        public const string RecordFormatStr = "record-id={0}";

        private const string startPage = "service/record/profiles";
        public static string GetStartPage()
        {
            return AdressStart + startPage;
        }

        public const string recordPage = "service/record/record";
        public static string GetRecordPage()
        {
            return AdressStart + recordPage;
        }

        private const string doctorsListForType = "service/record/doctors?hospital_id={0}&hospital_unit_id={1}";
        public static string GetListOfDoctorsForHospital(string hospital_id, string hospital_unit_id)
        {
            return AdressStart + string.Format(doctorsListForType, hospital_id, hospital_unit_id);
        }

        private const string doctorTimetable = "service/record/timetable?doctor_id={0}&profile_id={1}&hospital_id={2}&hospital_unit_id={3}";
        public static string GetTimetablForDoctor(string doctor_id, string profile_id, string hospital_id, string hospital_unit_id)
        {
            return AdressStart + string.Format(doctorTimetable, doctor_id, profile_id, hospital_id, hospital_unit_id);
        }

        private const string doctorsByType = "service/record/hospitals?profile_id={0}";
        public static string GetDoctorsByType(string profile_id)
        {
            return AdressStart + string.Format(doctorsByType, profile_id);
        }
    }
}
