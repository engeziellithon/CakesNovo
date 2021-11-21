using System.ComponentModel.DataAnnotations;

namespace Cakes.Api.ViewModel
{
    public class BaseVM
    {
        public BaseVM()
        {
            Skip = 0;
            Take = 20;
        }


        [Range(0, Int64.MaxValue, ErrorMessage = "O campo {0} deve ser maior que {1}")]
        public int Skip { get; set; }

        [Range(1, 1000, ErrorMessage = "O campo {0} deve ser maior que {1}")]
        public int Take { get; set; }
    }
}
