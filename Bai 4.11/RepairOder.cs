using System;

namespace RepairServiceTracker
{
    public class RepairOrder
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string DeviceType { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ReceivedDate { get; set; }
        public decimal EstimatedCost { get; set; }
        public string Status { get; set; } // Mới tiếp nhận, Đang sửa, Chờ linh kiện, Hoàn tất, Đã hủy
        public string ImagePath { get; set; }
    }
}