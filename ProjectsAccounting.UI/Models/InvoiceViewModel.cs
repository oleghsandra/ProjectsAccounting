using ProjectsAccounting.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccounting.UI.Models
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel(List<UserModel> allUsers, InvoiceModel invoice)
        {
            this.InvoiceModel = invoice;
            this.InvoicedUsers = new List<InvoicedUser>();

            foreach (var task in InvoiceModel.InvoicedTasks)
            {
                var user = allUsers.FirstOrDefault(u => u.UserId == task.UserId);

                if (user != null)
                {
                    var userInCollection = InvoicedUsers.FirstOrDefault(u => u.UserName == user.UserName);

                    if (userInCollection == null)
                    {
                        this.InvoicedUsers.Add(new InvoicedUser()
                        {
                            ExternalRate = task.UserExternalRate,
                            UserName = user == null ? "" : user.UserName,
                            Hours = task.ReportedHours
                        });
                    }
                    else
                    {
                        userInCollection.ExternalRate = task.UserExternalRate;
                        userInCollection.Hours += task.ReportedHours;
                    }
                }
            }
        }

        public InvoiceModel InvoiceModel { get; set; }

        public List<InvoicedUser> InvoicedUsers { get; set; }

        public double SubTotal
        {
            get
            {
                return InvoicedUsers.Sum(i => i.Total);
            }
        }

        public double Total
        {
            get
            {
                return SubTotal + SubTotal * (InvoiceModel.TaxRate / 100);
            }
        }
    }

    public class InvoicedUser
    {
        public string UserName { get; set; }

        public double ExternalRate { get; set; }

        public double Hours { get; set; }

        public double Total
        {
            get
            {
                return ExternalRate * Hours;
            }
        }
    }
}