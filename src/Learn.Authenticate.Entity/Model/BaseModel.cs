using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Model
{
    public abstract class BaseModel<TPrimaryKey> where TPrimaryKey : struct
    {
        public TPrimaryKey Id { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        [AllowNull]
        public virtual DateTime ModifyDate { get; set; }
        [AllowNull]
        public int ModifyUser { get; set; }
    }

    public abstract class BaseTreeModel<TPrimaryKey> where TPrimaryKey : struct
    {
        public TPrimaryKey Id { get; set; }
        public TPrimaryKey ParentId { get; set; }
        public virtual string Type { get; set; }
        public virtual int Index { get; set; }
        public virtual int Order { get; set; }
        public virtual string CodeData { get; set; }

        public virtual DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        [AllowNull]
        public virtual DateTime ModifyDate { get; set; }
        [AllowNull]
        public int ModifyUser { get; set; }
    }

    public class BasePageOutputModel<TModelOutput> where TModelOutput : class
    {
        public BasePageOutputModel(int totalItem, ICollection<TModelOutput> items)
        {
            this.TotalItem = totalItem;
            this.Items = items;
        }
        public virtual int TotalItem { get; set;}

        public virtual ICollection<TModelOutput> Items { get; set;}
    }

    public class BasePageInputModel
    {
        public virtual int SkipCount { get; set; } = 0;
        public virtual int MaxCountResult { get; set; } = 10;
        public virtual string Search { get; set; } = "";
    }

}
