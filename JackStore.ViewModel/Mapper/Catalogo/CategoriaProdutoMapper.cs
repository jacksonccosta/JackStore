﻿using JackStore.Common;
using JackStore.Data.Domain;
using JackStore.ViewModel;
using System.Collections.Generic;

namespace JackStore.ViewModel
{
    public static class CategoriaProdutoMapper
    {
        public static List<CategoriaProdutoViewModel> ToViewModel(this List<CategoriaProduto> fromList)
        {
            var to = new List<CategoriaProdutoViewModel>();

            foreach (var item in fromList)
            {
                to.Add(item.ToViewModel());
            }

            return to;
        }

        public static CategoriaProdutoViewModel ToViewModel(this CategoriaProduto from)
        {
            var slug = from.Nome.GetSlug();
            var to = new CategoriaProdutoViewModel { Nome = from.Nome, Slug = slug };
            return to;
        }
    }
}