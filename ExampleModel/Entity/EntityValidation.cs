using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace ExampleModel.Entity
{
    public partial class NorthwindEntities
    {
        protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, System.Collections.Generic.IDictionary<object, object> items)
        {
            //if (entityEntry.Entity is FundDecision)
            //{
            //    if (entityEntry.CurrentValues.GetValue<string>("ProductID").Contains("vb"))
            //    {
            //        var list = new List<System.Data.Entity.Validation.DbValidationError>();
            //        list.Add(new System.Data.Entity.Validation.DbValidationError("ProductID", "ProductID is not allow vb"));

            //        return new System.Data.Entity.Validation.DbEntityValidationResult(entityEntry, list);
            //    }
            //}

            return base.ValidateEntity(entityEntry, items);
        }
    }
}
