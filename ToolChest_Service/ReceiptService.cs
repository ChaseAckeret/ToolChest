using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolChest_Data;
using ToolChest_Models;

namespace ToolChest_Service
{
    public class ReceiptService
    {
        public bool CreateReceipt(ReceiptCreate model)
        {
            var entity =
                new Receipt()
                {
                    FKRentalID = model.RentalID,
                    AmountPaid = model.AmountPaid,
                    ActualStartDate = model.ActualStartDate,
                    ActualEndDate = model.ActualEndDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Receipts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateReceipt(ReceiptEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Receipts
                        .Single(e => e.FKRentalID == model.ReceiptID);

                entity.FKRentalID = model.ReceiptID;
                entity.AmountPaid = model.AmountPaid;
                entity.ActualStartDate = model.ActualStartDate;
                entity.ActualEndDate = model.ActualEndDate;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReceipt(int ReceiptId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Receipts
                    .Single(e => e.FKRentalID == ReceiptId);

                ctx.Receipts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
