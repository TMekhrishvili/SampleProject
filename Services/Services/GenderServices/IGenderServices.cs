using Domain.Models.GenderModel;
using Domain.Models.GeneralResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.GenderServices
{
    public interface IGenderServices
    {
        public Task<GeneralResponseModel<IEnumerable<GenderResponseModel>>> ListGet();
    }
}
