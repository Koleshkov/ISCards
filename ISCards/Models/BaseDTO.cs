using CommunityToolkit.Mvvm.ComponentModel;
using ISCards.Common.Mappings;
using ISCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCards.Models
{
    public partial class BaseDTO : ObservableObject
    {
        [ObservableProperty]
        private int id;
    }
}
