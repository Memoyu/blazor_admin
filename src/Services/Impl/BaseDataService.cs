﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbill_blazor_admin.Models.Base.Page;
using mbill_blazor_admin.Models.BaseData.Input;
using mbill_blazor_admin.Models.BaseData.Output;
using mbill_blazor_admin.Services.Base;

namespace mbill_blazor_admin.Services.Impl
{
    public class BaseDataService : IBaseDataService
    {
        private readonly CoreClient _client;
        public BaseDataService(CoreClient client)
        {
            _client = client;
        }
        public async Task<PagedDto<AssetModel>> GetAssetPages(AssetPageParams pagingDto)
        {
            // var url = CoreClient.GetSpliceUrlByObj(BaseDataUrl.GetAssetPages, pagingDto);
            return await _client.GetAsync<PagedDto<AssetModel>>(BaseDataUrl.GetAssetPages, pagingDto);
        }

        public async Task<List<AssetModel>> GetAssetParents()
        {
            return await _client.GetAsync<List<AssetModel>>(BaseDataUrl.GetAssetParents);
        }
    }
}