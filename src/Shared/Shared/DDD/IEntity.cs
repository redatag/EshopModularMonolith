using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DDD
{

    public interface IEntity<T> : IEntity
    {

        public T Id { get; set; }
    }


    //common props for each enity should have or need to include
    public interface IEntity
    {
        //tracking properties
        public DateTime CreatedAt  { get; set; }
        public string? CreatedBy  { get; set; }
        public DateTime? LastModified  { get; set; }
        public string? LastModifiedBy  { get; set; }
     }
}
