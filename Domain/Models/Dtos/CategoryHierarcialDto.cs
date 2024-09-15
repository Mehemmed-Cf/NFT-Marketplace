using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class CategoryHierarcialDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }

        public IEnumerable<CategoryHierarcialDto> Children { get; set; }
    }
}
