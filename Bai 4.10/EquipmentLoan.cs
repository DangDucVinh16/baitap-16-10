using System;

namespace LabEquipmentCheckout
{
    public class EquipmentLoan
    {
        public string LoanId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Có thể null nếu chưa trả
        public string Status { get; set; } // Đang mượn, Đã trả, Quá hạn
    }
}