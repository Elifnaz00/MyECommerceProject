namespace MyProject.WebUI.Models.AdminModel.OrderModel
{
    public class ActiveOrderViewModel
    {
        public List<OrderListModel> Orders { get; set; }
        public List<OrderStatusViewModel> OrderStatuses { get; set; }
    }
}
