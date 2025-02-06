using Entitys.Base;

namespace Entitys
{
    public class AppointmentReportEntity
    {
        public string AG_ID { get; set; }
        public string AG_IdPatient { get; set; }
        public string AG_IdDoctor { get; set; }
        public string AG_IdDoctorsTimetablesDate { get; set; }
        public string AG_IdDoctorsTimetablesTime { get; set; }
        public string AG_Status { get; set; }
        public DateTime AG_CreateDate { get; set; }
        public DateTime? AG_DeleteDate { get; set; }
        public string DO_Id { get; set; }
        public string DO_Name { get; set; }
        public string DO_CPF { get; set; }
        public string DO_Email { get; set; }
        public string DO_CRM { get; set; }
        public DateTime DO_CreateDate { get; set; }
        public decimal? DO_Amount { get; set; }
        public string DO_Specialty { get; set; }
        public int? DO_Score { get; set; }
        public string PA_Id { get; set; }
        public string PA_Name { get; set; }
        public string PA_CPF { get; set; }
        public string PA_Email { get; set; }
        public string PA_CRM { get; set; }
        public DateTime PA_CreateDate { get; set; }
        public decimal? PA_Amount { get; set; }
        public string PA_Specialty { get; set; }
        public int? PA_Score { get; set; }
        public string DT_Id { get; set; }
        public string DT_IdDoctor { get; set; }
        public DateTime DT_AvailableDate { get; set; }
        public DateTime DT_CreateDate { get; set; }
        public DateTime? DT_DeleteDate { get; set; }
        public string TM_Id { get; set; }
        public string TM_IdDoctorsTimetablesDate { get; set; }
        public string TM_Time { get; set; }
        public DateTime TM_CreateDate { get; set; }
        public DateTime? TM_DeleteDate { get; set; }
    }
}
