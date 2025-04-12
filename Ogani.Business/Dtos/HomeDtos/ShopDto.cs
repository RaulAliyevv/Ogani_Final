using Ogani.Business.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogani.Business.Dtos.HomeDtos
{
    public class ShopDto
    {
        public List<ProductDto> Products { get; set; } = [];
    }
}
