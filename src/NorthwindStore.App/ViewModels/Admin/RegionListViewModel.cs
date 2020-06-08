using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin;
using Riganti.Utils.Infrastructure;

namespace NorthwindStore.App.ViewModels.Admin
{
    public class RegionListViewModel : AdminViewModel
    {
        private readonly AdminRegionsFacade pageFacade;

        public RegionListViewModel(AdminRegionsFacade pageFacade)
        {
            this.pageFacade = pageFacade;

            Regions = new BusinessPackDataSet<RegionDTO>()
            {
                PagingOptions =
                {
                    PageSize = 50
                },
                SortingOptions =
                {
                    SortExpression = nameof(RegionDTO.Id)
                }
            };
        }

        public override string PageTitle => "Regions";

        public override string HighlightedMenuPath => "Regions";

        public BusinessPackDataSet<RegionDTO> Regions { get; set; }

        public override Task PreRender()
        {
            pageFacade.FillDataSet(Regions);

            return base.PreRender();
        }

        public void Delete(int id)
        {
            pageFacade.Delete(id);
        }
    }
}

